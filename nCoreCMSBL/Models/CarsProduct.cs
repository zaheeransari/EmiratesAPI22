using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class CarsProduct
    {
        [Key]
        public int CarsProductId { get; set; }
        public string CarsProductName1 { get; set; }
        public string CarsProductDescription { get; set; }
        public string CarsKilometers { get; set; }
        public string CarsColor { get; set; }
        public string CarsDoors { get; set; }
        public string CarsPrice { get; set; }
        public string CarsImages { get; set; }
        //public List<CarImages> CarsImage { get; set; }
        //public string CarsImagess { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
        public string SessionId { get; set; }
        //public int CreatedBy { get; set; }
    }

    public class CarsProductDto
    {        
        public int CarsProductId { get; set; }
        public string CarsProductName1 { get; set; }
        public string CarsProductDescription { get; set; }
        public string CarsKilometers { get; set; }
        public string CarsColor { get; set; }
        public string CarsDoors { get; set; }
        public string CarsPrice { get; set; }
        public string CarsImages { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class CarsDetailsDto
    {
        public int CarsProductId { get; set; }
        public string CarsProductName1 { get; set; }
        public string CarsProductDescription { get; set; }
        public string CarsKilometers { get; set; }
        public string CarsColor { get; set; }
        public string CarsDoors { get; set; }
        public string CarsPrice { get; set; }
        //public string CarsImages { get; set; }
        public List<CarImagesDto> CarsImagess { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public sealed class CarProducResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public CarProductMsg results { get; set; }
    }
    public sealed class CarDetailsResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public CarProductDetails results { get; set; }
    }
    public class CarProductMsg
    {
        public List<CarsProductDto> appCarProduct { get; set; }
        public string apiMessage { get; set; }
    }
    public class CarProductDetails
    {
        public List<CarsDetailsDto> appCarDetails { get; set; }
        public string apiMessage { get; set; }
    }
    public class CarImagesDto
    {        
        public string ProductImages { get; set; }
    }
    public class CarsImagesDto
    {        
        public int CarsImageId { get; set; }
        public string CarsImageName { get; set; }
        public string CarsImages { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
        public int SessionId { get; set; }
    }
}
