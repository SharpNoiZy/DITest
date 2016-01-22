using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectReleaseProcess : EntityBase
	{
		public Guid ProjectReleaseId { get; set; }

		public String Name { get; set; }

		public String Description { get; set; }

		public string UsedLanguage { get; set; }

		public string BuildsDirectory { get; set; }

		public string Build { get; set; }

		public string ProcessExecutable { get; set; }

		public string Configuration { get; set; }

		public Byte Order { get; set; }



		public virtual ProjectRelease Release { get; set; }

		public virtual ICollection<JobStep> JobSteps { get; set; }

		// public virtual ICollection<ProjectReleaseProcessProtectedIO> ProtectedIOs { get; set; }
	}
}