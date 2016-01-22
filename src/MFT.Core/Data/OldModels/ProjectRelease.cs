using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectRelease : EntityBase
	{
		public Guid ProjectId { get; set; }

		public int ReleaseNr { get; set; }

		public bool IsClosed { get; set; }



		public virtual Project Project { get; set; }

		public virtual ICollection<ProjectReleaseDeployment> Deployments { get; set; }

		public virtual ICollection<ProjectReleaseProcess> Processes { get; set; }

		public virtual ICollection<Job> Jobs { get; set; }
	}
}