using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
	public class UserAssociatedRoles
	{
		public Users User { get; set; }

		public List<UserRoles> UserRoles { get; set; }

		public LoginModel LoginModel { get; set; }
	}
}
