using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
	public class UserRoles
	{
		public int RoleID { get; set; }

		public string RoleName { get; set; }

		public long UserID { get; set; }

		public bool IsRolePermission { get; set; }

		public int ModifiedBy { get; set; }

		public string ModifiedByName { get; set; }

		public DateTime? ModifiedDate { get; set; }
	}
}
