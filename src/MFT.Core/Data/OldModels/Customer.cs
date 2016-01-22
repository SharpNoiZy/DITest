using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class Customer
	{
		/// <summary>
		/// Technical name of the customer without special chars
		/// </summary>
		public string Id { get; set; }

		public string Name { get; set; }

		public PoolVersion PoolVersion { get; set; }

		public string TimezoneId { get; set; }

		public bool Deleted { get; set; }



		public virtual ICollection<Project> Projects { get; set; }

		public virtual ICollection<CustomerGLN> GLNs { get; set; }
	}
}