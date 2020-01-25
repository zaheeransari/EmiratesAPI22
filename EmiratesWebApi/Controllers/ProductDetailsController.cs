using nCoreCMSBL.Models;
using nCoreCMSBL.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EmiratesWebApi.Controllers
{
    [RoutePrefix("api/ProductDetails")]
    public class ProductDetailsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetProductDetails(int productTypeId)
        {
            try
            {
                var data = ProductRepository.GetProductDetails(productTypeId);
                if (data != null)
                {
                    var product = data.Tables[0].Rows;
                    List<ProductDetails> PDList = new List<ProductDetails>();
                    if (data.Tables[0].Rows.Count > 0)
                    {
                        for (int item = 0; item < data.Tables[0].Rows.Count; item++)
                        {
                            ProductDetails PD = new ProductDetails();
                            PD.ProductId = Convert.ToInt32(data.Tables[0].Rows[item]["CarsProductId"].ToString());
                            PD.CountryID = Convert.ToInt32(data.Tables[0].Rows[item]["CountryID"].ToString());
                            PD.Mobile = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["Mobile"].ToString()) ? data.Tables[0].Rows[item]["Mobile"].ToString() : string.Empty;
                            PD.CityID = Convert.ToInt32(data.Tables[0].Rows[item]["CityID"].ToString());
                            PD.ProductName = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsProductName"].ToString()) ? data.Tables[0].Rows[item]["CarsProductName"].ToString() : string.Empty;
                            PD.ProductDescription = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsProductDescription"].ToString()) ? data.Tables[0].Rows[item]["CarsProductDescription"].ToString() : string.Empty;
                            PD.Price = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsPrice"].ToString()) ? data.Tables[0].Rows[item]["CarsPrice"].ToString() : string.Empty;
                            PD.ProductTypes = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["ProductTypes"].ToString()) ? data.Tables[0].Rows[item]["ProductTypes"].ToString() : string.Empty;
                            PD.Color = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsColor"].ToString()) ? data.Tables[0].Rows[item]["CarsColor"].ToString() : string.Empty;
                            PD.Doors = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsDoors"].ToString()) ? data.Tables[0].Rows[item]["CarsDoors"].ToString() : string.Empty;
                            PD.Kilometers = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsKilometers"].ToString()) ? data.Tables[0].Rows[item]["CarsKilometers"].ToString() : string.Empty;
                            PD.Images = !string.IsNullOrEmpty(data.Tables[0].Rows[item]["CarsImages"].ToString()) ? data.Tables[0].Rows[item]["CarsImages"].ToString() : string.Empty;

                            List<ImageDetails> ImgDetailList = new List<ImageDetails>();

                            DataRow[] foundRows = data.Tables[1].Select("ProductID = '" + PD.ProductId + "'");
                            DataTable dtImages = new DataTable();
                            if (foundRows.Length > 0)
                            {
                                dtImages = foundRows.CopyToDataTable<DataRow>();
                            }

                            for (int Img = 0; Img < dtImages.Rows.Count; Img++)
                            {
                                ImageDetails ImgDetails = new ImageDetails();
                                ImgDetails.ImagesUrl = dtImages.Rows[Img]["CarsImages"].ToString();

                                ImgDetailList.Add(ImgDetails);
                            }

                            PD.ImageDetails = ImgDetailList;

                            PDList.Add(PD);
                        }                                                    
                    }

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                   
                    response.Content = new StringContent(JsonConvert.SerializeObject(PDList, Formatting.None), Encoding.UTF8, "application/json");
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
