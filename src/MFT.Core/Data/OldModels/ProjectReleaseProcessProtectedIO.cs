using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectReleaseProcessProtectedIO : EntityBase
	{
		public Guid ProjectReleaseProcessId { get; set; }

		public string Path { get; set; }


		// public virtual ProjectReleaseProcess Process { get; set; }
	}
}