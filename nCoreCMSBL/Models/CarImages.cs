using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class CarImages
    {
        //[Key]
        public int CarsImageId { get; set; }
        public string CarsImageName { get; set; }
        public string CarsImages { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
        public int SessionId { get; set; }
    }
}
