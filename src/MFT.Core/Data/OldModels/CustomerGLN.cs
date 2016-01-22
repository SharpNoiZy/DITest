using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class CustomerGLN : EntityBase
	{
		public string CustomerId { get; set; }

		public Guid EnvironmentId { get; set; }

		public string Description { get; set; }



		public virtual Customer Customer { get; set; }
	}
}