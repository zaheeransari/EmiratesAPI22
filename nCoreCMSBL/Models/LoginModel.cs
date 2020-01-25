using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
	public class LoginModel
	{
		public long UserID { get; set;}

		public string LoginUserName { get; set; }

		public string LoginPassword { get; set; }
	}
}
