using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class UserProductDetails
    {
        public int UserId { get; set; }
        public string Mobile { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<ProductDetails> ProductDetails { get; set; }
    }

    public class ProductDetails
    {
        public int ProductId { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public string Mobile { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Kilometers { get; set; }
        public string ProductTypes { get; set; }
        public string Color { get; set; }
        public string Doors { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }

        public List<ImageDetails> ImageDetails { get; set; }
    }

    public class ImageDetails
    {
        //public int ImageId { get; set; }
        //public string ImageName { get; set; }
        public string ImagesUrl { get; set; }
        //public int ProductID { get; set; }
    }

}
