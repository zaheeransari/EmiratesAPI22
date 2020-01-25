using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class ProductPriceList
    {
        [Key]
        public int PriceId { get; set; }
        public int Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductList ProductLists { get; set; }
    }
}
