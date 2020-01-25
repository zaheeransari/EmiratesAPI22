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
    public sealed class CarsRepository
    {
        public static List<CarsProductDto> GetProductList()
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0,3);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
                return Util.ConvertDataTable<CarsProductDto>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static List<CarImages> GetAllImages()
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 4);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
                return Util.ConvertDataTable<CarImages>(dt);

            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static List<CarsDetailsDto> GetProductById(int productID)
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 5);
                objWLSql.AddParameter("@CarsProductId", DbType.String, ParameterDirection.Input, 0, productID);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
                return Util.ConvertDataTable<CarsDetailsDto>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static List<CarsDetailsDto> GetProductTypes(ProductTypesDto productID)
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 7);
                objWLSql.AddParameter("@ProductTypeId", DbType.String, ParameterDirection.Input, 0, productID.ProductTypeId);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
                return Util.ConvertDataTable<CarsDetailsDto>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static List<CarImages> GetAllCarImages()
        {
            try
            {
                DataTable dt;
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 4);
                dt = objWLSql.ExecuteDataSet("emi_carproduct").Tables[0];
                return Util.ConvertDataTable<CarImages>(dt);
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }
        public static int AddProduct(CarsProduct carsProduct)
        {
            try
            {
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@paramType", DbType.Int32, ParameterDirection.Input, 0, 2);
                objWLSql.AddParameter("@CarsProductName1", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsProductName1);
                objWLSql.AddParameter("@CarsProductDescription", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsProductDescription);
                objWLSql.AddParameter("@CarsColor", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsColor);
                objWLSql.AddParameter("@CarsDoors", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsDoors);
                objWLSql.AddParameter("@CarsKilometers", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsKilometers);
                objWLSql.AddParameter("@CarsPrice", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsPrice);
                objWLSql.AddParameter("@IsActive", DbType.String, ParameterDirection.Input, 0, carsProduct.IsActive);
                objWLSql.AddParameter("@SessionId", DbType.String, ParameterDirection.Input, 0, carsProduct.SessionId);
                //objWLSql.AddParameter("@CreatedBy", DbType.String, ParameterDirection.Input, 0, carsProduct.CreatedBy);
                return Convert.ToInt32(objWLSql.ExecuteScalar("emi_carproduct"));
            }
            catch (Exception ex)
            {
                throw wlLogging.HandleEx(ex);
            }
        }

        public static void UpdateProduct(CarsProduct carsProduct)
        {
            try
            {
                wlSQL objWLSql = new wlSQL();
                objWLSql.AddParameter("@CarsProductId", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsProductId);
                objWLSql.AddParameter("@Name", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsProductName1);
                objWLSql.AddParameter("@CarsProductDescription", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsProductDescription);
                objWLSql.AddParameter("@CarsColor", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsColor);
                objWLSql.AddParameter("@CarsDoors", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsDoors);
                //objWLSql.AddParameter("@CarsImagesUrl", DbType.String, ParameterDirection.Input, 0, carsProduct.CarsImagesUrl);
                objWLSql.AddParameter("@CarsKilometers", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsKilometers);
                objWLSql.AddParameter("@CarsPrice", DbType.Int32, ParameterDirection.Input, 0, carsProduct.CarsPrice);
                objWLSql.ExecuteNonQuery("emi_carproduct");
            }
            catch (Exception ex)
            {
                wlLogging.HandleEx(ex);
            }
        }
    }
}
