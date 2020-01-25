using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace nCoreCMSBL.Models
{
	public class Roles
	{
		public int RoleID { get; set; }

		public string RowID { get; set; }

		public string RoleName { get; set; }

		public string RoleDescription { get; set; }

		public bool IsActive { get; set; }

		public string Note { get; set; }

        public int CreatedBy { get; set; }

        public string CreatedByName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string ModifiedByName { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public ModuleFunctionPermissions ModuleFunctionPermissions { get; set;}
	}
}
