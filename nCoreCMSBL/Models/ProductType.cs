using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeDescription { get; set; }
        //public string ProductImages { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsActive { get; set; }
    }
    public class ProductTypesDto
    {
        public int ProductTypeId { get; set; }
    }
}
