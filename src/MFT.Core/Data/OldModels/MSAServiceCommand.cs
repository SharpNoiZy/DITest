using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class MSAServiceCommand : EntityBase
	{
		public string ServiceId { get; set; }

		public ServiceCommandType Command { get; set; }

		public string Parameter { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ExecutedAt { get; set; }
	}
}