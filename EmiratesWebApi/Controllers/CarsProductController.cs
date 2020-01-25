using EmiratesWebApi.Models;
using nCoreCMSBL.Models;
using nCoreCMSBL.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EmiratesWebApi.Controllers
{
    [RoutePrefix("api/car")]
    public class CarsProductController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetCarList()
        {
            try
            {
                ApplicationMessage appmessage = new ApplicationMessage();
                CarProducResponse carResponse = new CarProducResponse();
                CarProductMsg carresults = new CarProductMsg();

                List<CarsProductDto> carlst = new List<CarsProductDto>();
                carresults.appCarProduct = CarsRepository.GetProductList();
                carResponse.results = carresults;
                
                carResponse.status = true;
                if (carresults.appCarProduct.Count > 0)
                {
                    carresults.apiMessage = appmessage.carproductSuccessfully;
                }
                else
                {
                    carresults.apiMessage = appmessage.carproductFails;
                }
                carResponse.message = appmessage.executedSuccessfully;

                if (carresults.appCarProduct != null)
                {
                    string imgPath = ConfigurationManager.AppSettings["imgPath"];
                    foreach (var item in carresults.appCarProduct)
                    {
                        CarsProductDto carsProduct = new CarsProductDto();
                        carsProduct.CarsProductId = item.CarsProductId;
                        carsProduct.CarsProductName1 = item.CarsProductName1;
                        carsProduct.CarsProductDescription = item.CarsProductDescription;
                        carsProduct.CarsPrice = item.CarsPrice;
                        carsProduct.CarsColor = item.CarsColor;
                        carsProduct.CarsKilometers = item.CarsKilometers;
                        carsProduct.CarsDoors = item.CarsDoors;
                        carsProduct.CarsImages = imgPath + item.CarsImages;
                        carlst.Add(carsProduct);
                    }
                    carresults.appCarProduct = carlst;
                    //carresponse.results = carlst;
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(carResponse, Formatting.None), Encoding.UTF8, "application/json");
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

        [HttpGet]
        //[Route("{id}")]
        public HttpResponseMessage GetCarById(int id)
        {
            try
            {
                ApplicationMessage appmessage = new ApplicationMessage();
                CarDetailsResponse carResponse = new CarDetailsResponse();
                CarProductDetails carresults = new CarProductDetails();

                List<CarsDetailsDto> carlst = new List<CarsDetailsDto>();
                carresults.appCarDetails = CarsRepository.GetProductById(id);
                carResponse.results = carresults;
                carresults.apiMessage = appmessage.carproductSuccessfully;
                carResponse.status = true;
                carResponse.message = appmessage.executedSuccessfully;

                List<CarImages> lstimages = new List<CarImages>();
                List<CarImagesDto> lstimages2 = new List<CarImagesDto>();
                CarImagesDto carImagesdd = new CarImagesDto();
                lstimages = CarsRepository.GetAllImages();




                if (carresults.appCarDetails != null)
                {
                    string imgPath = ConfigurationManager.AppSettings["imgPath"];
                    foreach (var item in carresults.appCarDetails)
                    {
                        CarsDetailsDto carsProduct = new CarsDetailsDto();
                        carsProduct.CarsProductId = item.CarsProductId;
                        carsProduct.CarsProductName1 = item.CarsProductName1;
                        carsProduct.CarsProductDescription = item.CarsProductDescription;
                        carsProduct.CarsPrice = item.CarsPrice;
                        carsProduct.CarsColor = item.CarsColor;
                        carsProduct.CarsKilometers = item.CarsKilometers;
                        carsProduct.CarsDoors = item.CarsDoors;
                        foreach (var mg in lstimages)
                        {
                            if (mg.SessionId == item.CarsProductId)
                            {
                                carImagesdd.ProductImages = imgPath + mg.CarsImages;
                                lstimages2.Add(carImagesdd);
                            }
                            
                            //carsProduct.CarsImages = imgPath + item.CarsImages;
                        }
                        carsProduct.CarsImagess = lstimages2;
                        carlst.Add(carsProduct);
                    }
                    carresults.appCarDetails = carlst;
                    //carresponse.results = carlst;
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(carResponse, Formatting.None), Encoding.UTF8, "application/json");
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

        [HttpPost]
        [Route("GetProductTypes")]
        public HttpResponseMessage GetProductTypes([FromBody]ProductTypesDto productTypes)
        {
            try
            {
                ApplicationMessage appmessage = new ApplicationMessage();
                CarDetailsResponse carResponse = new CarDetailsResponse();
                CarProductDetails carresults = new CarProductDetails();

                List<CarsDetailsDto> carlst = new List<CarsDetailsDto>();
                carresults.appCarDetails = CarsRepository.GetProductTypes(productTypes);
                carResponse.results = carresults;
                //carresults.apiMessage = appmessage.carproductSuccessfully;
                carResponse.status = true;
                carResponse.message = appmessage.executedSuccessfully;

                List<CarImages> lstimages = new List<CarImages>();
                List<CarImagesDto> lstimages2 = new List<CarImagesDto>();
                CarImagesDto carImagesdd = new CarImagesDto();
                lstimages = CarsRepository.GetAllImages();

                if (carresults.appCarDetails.Count > 0)
                {
                    carresults.apiMessage = appmessage.carproductSuccessfully;
                }
                else
                {
                    carresults.apiMessage = appmessage.carproductFails;
                }


                if (carresults.appCarDetails != null)
                {
                    string imgPath = ConfigurationManager.AppSettings["imgPath"];
                    foreach (var item in carresults.appCarDetails)
                    {
                        CarsDetailsDto carsProduct = new CarsDetailsDto();
                        carsProduct.CarsProductId = item.CarsProductId;
                        carsProduct.CarsProductName1 = item.CarsProductName1;
                        carsProduct.CarsProductDescription = item.CarsProductDescription;
                        carsProduct.CarsPrice = item.CarsPrice;
                        carsProduct.CarsColor = item.CarsColor;
                        carsProduct.CarsKilometers = item.CarsKilometers;
                        carsProduct.CarsDoors = item.CarsDoors;
                        foreach (var mg in lstimages)
                        {
                            if (mg.SessionId == item.CarsProductId)
                            {
                                carImagesdd.ProductImages = imgPath + mg.CarsImages;
                                lstimages2.Add(carImagesdd);
                            }

                            //carsProduct.CarsImages = imgPath + item.CarsImages;
                        }
                        carsProduct.CarsImagess = lstimages2;
                        carlst.Add(carsProduct);
                    }
                    carresults.appCarDetails = carlst;
                    //carresponse.results = carlst;
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(carResponse, Formatting.None), Encoding.UTF8, "application/json");
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
