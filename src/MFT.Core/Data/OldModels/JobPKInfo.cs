using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFT.Core.Data.Models
{
	public class JobPKInfo : EntityBase
	{
		public Int64 JobId { get; set; }

		public string UnitDescriptor { get; set; }

		public string Gtin { get; set; }

		public string GLN { get; set; }

		public string TargetMarket { get; set; }

		/// <summary>
		/// Descrips if this item is child of another item
		/// </summary>
		public string ParentGtin { get; set; }



		public virtual Job Job { get; set; }
	}
}
