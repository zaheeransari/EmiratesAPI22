using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class ProductList
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName1 { get; set; }
        public string ProductName2 { get; set; }
        public string ProductName3 { get; set; }
        public string ProductDescription { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }

        public int? ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductTypes { get; set; }
    }
}
