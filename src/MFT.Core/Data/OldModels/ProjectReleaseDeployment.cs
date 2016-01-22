using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectReleaseDeployment : EntityBase
	{
		public Guid ReleaseId { get; set; }

		public Guid EnvironmentId { get; set; }

		public bool IsActive { get; set; }

		public bool StopCustomerTransfer { get; set; }

		public bool DebugMode { get; set; }

		public DateTime? FirstActivatedAt { get; set; }

		public int FailedCounter { get; set; }



		public virtual ProjectRelease Release { get; set; }

		public virtual Environment Environment { get; set; }
	}
}