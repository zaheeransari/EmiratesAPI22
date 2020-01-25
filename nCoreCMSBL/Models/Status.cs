using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
	public class Status
	{
		public int StatusID { get; set; }

		public string StatusName { get; set; }
	}

	public enum StatusType
	{
		Active = 1,
		Inactive = 2,
		Susupended = 3
	}
}
