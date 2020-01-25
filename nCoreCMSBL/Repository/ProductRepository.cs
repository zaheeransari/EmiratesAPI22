using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Core;

namespace nCoreCMSBL.Repository
{
    public class ProductRepository
    {
        public static DataSet GetProductDetails(int productTypeId)
        {
            try
            {
                DataSet ds;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@ProductTypes", DbType.Int32, ParameterDirection.Input, 0, productTypeId);
                ds = objWLSql.ExecuteDataSet("emi_ProductsDetails_ProductTypes");
                return ds;
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
    }
}
