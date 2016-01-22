using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class JobStep : EntityBase
	{
		public Int64 JobId { get; set; }

		public Guid ProjectReleaseProcessId { get; set; }

		public string Arguments { get; set; }

		public DateTime Started { get; set; }

		public DateTime? Ended { get; set; }

		public JobStatus Status { get; set; }

		public int ExitCode { get; set; }



		public virtual Job Job { get; set; }

		public virtual ProjectReleaseProcess ReleaseProcess { get; set; }

		public virtual ICollection<LogEntry> Logs { get; set; }
	}
}
