using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public enum UserStatus : int
    {
        Active = 1,
        Inactive = 2,
        Suspended = 3
    }

    public sealed class Users
	{
		#region Properties
		public int UserID { get; set; }
		public string RowID { get; set; }
		public string LoginUserName { get; set; }
		public string LoginPassword { get; set; }
		public string PasswordNew { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string ContactNo { get; set; }
		public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
		public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string ImageLink { get; set; }
		public string ImagePublicID { get; set; }
        public string ImageName { get; set; }
        public string Role { get; set; }
		public string RoleIDs { get; set; }
		public bool SendApprovalEmail { get; set; }
		public bool IsSocialLogin { get; set; }
		public string SocialID { get; set; }
		public string SocialImageURL { get; set; }
		public string FullName
		{
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}
		#endregion
	}
    public sealed class UsersDto
    {
        public int UserID { get; set; }
        public string LoginUserName { get; set; }
        public string EmailAddress { get; set; }
    }
	public sealed class SearchForm
	{
		public string SearchText { get; set; }
		public bool Active { get; set; }
		public int StatusID { get; set; }
        public int TypeID { get; set; }
    }
    public sealed class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        public RegistrationMsg results { get; set; }
    }
    public class RegistrationMsg
    {        
        public string apiMessage { get; set; }
    }
}
