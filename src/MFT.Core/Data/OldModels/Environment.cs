using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class Environment : EntityBase
	{
		public string Name { get; set; }

		public string DataRootDirectory { get; set; }

		public string MappingsRootDirectory { get; set; }



		public virtual ICollection<Job> Jobs { get; set; }

		public virtual ICollection<ProjectReleaseDeployment> Deployments { get; set; }

		public virtual ICollection<MSAService> Services { get; set; }
	}
}