using nCoreCMSBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Core;

namespace nCoreCMSBL.Repository
{
    [Serializable]
    public sealed class VersionRepository
    {
        public static DataTable GetVersion()
        {
            try
            {
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 1);
                return objWLSql.ExecuteDataSet("emi_version").Tables[0];
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static List<AppVersions> GetAllVersion()
        {
            try
            {
                //wlSQL objWLSql = new wlSQL();
                //objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 2);
                //return objWLSql.ExecuteDataSet("emi_version").Tables[0];


                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 2);
                dt = objWLSql.ExecuteDataSet("emi_version").Tables[0];
                return Util.ConvertDataTable<AppVersions>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
    }
}
