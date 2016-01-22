using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class MSAServiceTransferCheck : EntityBase
	{
		public string ServiceId { get; set; }

		public DateTime CheckDate { get; set; }

		public int FoundPackages { get; set; }

		public int FoundPackagesForCustomers { get; set; }

		public Int64 FoundPackagesBytes { get; set; }




		public virtual MSAService Service { get; set; }

		public virtual ICollection<Job> Jobs { get; set; }
	}
}