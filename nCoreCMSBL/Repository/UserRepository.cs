using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nCoreCMSBL.Models;
using System.Data;
using WL.Core;
using System.Globalization;
using System.Data.SqlClient;

namespace nCoreCMSBL.Repository
{
	[Serializable]
	public sealed class UserRepository
	{
		//Authentication
		public static Users ValidateUser(string userName, string password)
		{
			IDataReader dr = null;
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserName", DbType.String, ParameterDirection.Input, 0, userName);
				objWLSql.AddParameter("@Password", DbType.String, ParameterDirection.Input, 0, password);
				dr = objWLSql.Execute("p_Users_sel_byUserIDAndPassword");
			}
			catch (Exception ex)
			{
				wlLogging.HandleEx(ex);
			}
			return Util.ContructList<Users>(dr).FirstOrDefault();
		}

		public static string ValidateExternalUser(External externalUser)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@SocialID", DbType.String, ParameterDirection.Input, 0, externalUser.Id);
				objWLSql.AddParameter("@LastName", DbType.String, ParameterDirection.Input, 0, externalUser.LastName);
				objWLSql.AddParameter("@FirstName", DbType.String, ParameterDirection.Input, 0, externalUser.FirstName);
				objWLSql.AddParameter("@Email", DbType.String, ParameterDirection.Input, 0, externalUser.Email);
				objWLSql.AddParameter("@PhotoUrl", DbType.String, ParameterDirection.Input, 0, externalUser.PhotoUrl);
				return Convert.ToString(objWLSql.ExecuteScalar("p_Users_ins_External"));
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

        public static bool CheckEmailExists(string emailAddress)
        {
            try
            {
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@EmailAddress", DbType.String, ParameterDirection.Input, 0, emailAddress);
                object o = objWLSql.ExecuteScalar("p_Users_sel_IsExistEmail");
                bool flag = false;
                if (o != null)
                {
                    int count = Convert.ToInt32(o.ToString(), CultureInfo.CurrentCulture);
                    if (count > 0)
                    {
                        flag = true;
                    }
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }

        public static bool IsExistUser(string loginUserName)
        {
            try
            {
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@LoginUserName", DbType.String, ParameterDirection.Input, 0, loginUserName);
                object o = objWLSql.ExecuteScalar("p_Users_sel_IsExistUser");
                bool flag = false;
                if (o != null)
                {
                    int count = Convert.ToInt32(o.ToString(), CultureInfo.CurrentCulture);
                    if (count > 0)
                    {
                        flag = true;
                    }
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }

		public static List<Status> GetUserStatusList()
		{
			try
			{
				DataTable dt;
				wlSQL objWLSql = new wlSQL();
				dt = objWLSql.ExecuteDataSet("p_LookupStatuses_sel").Tables[0];
				return Util.ConvertDataTable<Status>(dt);
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}


		public static List<Users> GetLoginDetails(string emailAddress)
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@EmailAddress", DbType.String, ParameterDirection.Input, 0, emailAddress);
                dt = objWLSql.ExecuteDataSet("p_Users_sel_LoginDetails").Tables[0];
                return Util.ConvertDataTable<Users>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }

        public static List<UsersDto> GetUserList()
		{
			try
			{
				DataTable dt;
				wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 6);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
				return Util.ConvertDataTable<UsersDto>(dt);
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

		public static List<UserRoles> GetUserRolePermissions(int _userID = 0)
		{
			try
			{
				DataTable dt;
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, _userID);
				dt = objWLSql.ExecuteDataSet("p_UserRoles_sel_byID").Tables[0];
				return Util.ConvertDataTable<UserRoles>(dt);
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

		public static int AddUser(Users user)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@FirstName", DbType.String, ParameterDirection.Input, 0, user.FirstName);
				objWLSql.AddParameter("@LastName", DbType.String, ParameterDirection.Input, 0, user.LastName);
				objWLSql.AddParameter("@EmailAddress", DbType.String, ParameterDirection.Input, 0, user.EmailAddress);
				objWLSql.AddParameter("@StatusID", DbType.Int32, ParameterDirection.Input, 0, user.StatusID);
				objWLSql.AddParameter("@CreatedBy", DbType.Int32, ParameterDirection.Input, 0, user.CreatedBy);
                return Convert.ToInt32(objWLSql.ExecuteScalar("p_Users_ins"));
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

		public static void RegisterUser(Register obj)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
                //objWLSql.AddParameter("@FullName", DbType.String, ParameterDirection.Input, 0, obj.FullName);
                objWLSql.AddParameter("@Mobile", DbType.String, ParameterDirection.Input, 0, obj.Mobile);
                objWLSql.AddParameter("@UserName", DbType.String, ParameterDirection.Input, 0, obj.UserName);
				objWLSql.AddParameter("@Password", DbType.String, ParameterDirection.Input, 0, obj.Password);
				objWLSql.AddParameter("@Email", DbType.String, ParameterDirection.Input, 0, obj.Email);
                objWLSql.AddParameter("@CountryID", DbType.Int32, ParameterDirection.Input, 0, obj.CountryID);
                objWLSql.AddParameter("@CityID", DbType.Int32, ParameterDirection.Input, 0, obj.CityID);

                objWLSql.ExecuteNonQuery("p_Users_register");
			}
			catch (Exception ex)
			{
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    //Violation of primary key/Unique constraint can be handled here. Also you may //check if Exception Message contains the constraint Name 
                }
            }
		}

		public static void UpdateUser(Users user)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, user.UserID);
				objWLSql.AddParameter("@FirstName", DbType.String, ParameterDirection.Input, 0, user.FirstName);
				objWLSql.AddParameter("@LastName", DbType.String, ParameterDirection.Input, 0, user.LastName);
				objWLSql.AddParameter("@EmailAddress", DbType.String, ParameterDirection.Input, 0, user.EmailAddress);
				objWLSql.AddParameter("@StatusID", DbType.Int32, ParameterDirection.Input, 0, user.StatusID);
				objWLSql.AddParameter("@ModifiedBy", DbType.Int32, ParameterDirection.Input, 0, user.ModifiedBy);
				objWLSql.ExecuteNonQuery("p_Users_upd");
			}
			catch (Exception ex)
			{
				wlLogging.HandleEx(ex);
			}
		}

		public static void UpdateUserRoles(UserRoles _Userrole)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, _Userrole.UserID);
				objWLSql.AddParameter("@RoleID", DbType.Int32, ParameterDirection.Input, 0, _Userrole.RoleID);
				objWLSql.AddParameter("@IsRolePermission", DbType.Boolean, ParameterDirection.Input, 0, _Userrole.IsRolePermission);
				objWLSql.AddParameter("@ModifiedBy", DbType.Int32, ParameterDirection.Input, 0, _Userrole.ModifiedBy);
				objWLSql.ExecuteNonQuery("p_UserRoles_upd");
			}
			catch (Exception ex)
			{
				wlLogging.HandleEx(ex);
			}
		}

		public static void UpdatePassword(LoginModel _model)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, _model.UserID);
				objWLSql.AddParameter("@Password", DbType.String, ParameterDirection.Input, 0, _model.LoginPassword);
				objWLSql.ExecuteNonQuery("p_Users_ChangePassword");
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

		public static void UpdateProfileImage(Users user)
		{
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, user.UserID);
				objWLSql.AddParameter("@ImageName", DbType.String, ParameterDirection.Input, 0, user.ImageName);
				objWLSql.AddParameter("@ModifiedBy", DbType.Int64, ParameterDirection.Input, 0, user.ModifiedBy);
				objWLSql.ExecuteNonQuery("p_Users_UpdateImage");
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
		}

		public static LoginModel GetAccountInfo(long _userID = 0)
		{
			IDataReader dr = null;
			try
			{
				wlSQL objWLSql = new wlSQL();
				objWLSql.AddParameter("@UserID", DbType.Int64, ParameterDirection.Input, 0, _userID);
				dr = objWLSql.Execute("p_Users_sel_AccountInfo");
			}
			catch (Exception ex)
			{
				throw wlLogging.HandleEx(ex);
			}
			return Util.ContructList<LoginModel>(dr).FirstOrDefault();
		}

		//public static void UpdateUser(Users user)
		//{
		//	try
		//	{
		//		wlSQL objWLSql = new wlSQL();
		//		objWLSql.AddParameter("@UserID", DbType.Int32, ParameterDirection.Input, 0, user.UserID);
		//		objWLSql.AddParameter("@DisplayName", DbType.String, ParameterDirection.Input, 0, user.DisplayName);
		//		objWLSql.AddParameter("@Password", DbType.String, ParameterDirection.Input, 0, user.Password);
		//		objWLSql.AddParameter("@Email", DbType.String, ParameterDirection.Input, 0, user.Email);
		//		objWLSql.ExecuteNonQuery("p_Users_upd");
		//	}
		//	catch (Exception ex)
		//	{
		//		wlLogging.HandleEx(ex);
		//	}
		//}
	}
}
