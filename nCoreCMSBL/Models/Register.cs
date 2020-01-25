using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
	public class Register
	{
        //public string FullName { get; set; }        
        public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
        public string Mobile { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
    }
}
