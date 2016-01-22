using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectEnvironmentConfig : EntityBase
	{
		public Guid ProjectId { get; set; }

		public Guid EnvironmentId { get; set; }

		public string DataDirectory { get; set; }

		public string MappingDirectory { get; set; }
	}
}