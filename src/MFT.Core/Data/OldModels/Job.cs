using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	/// <summary>
	/// A job is one mapping task. It's created and started by the MSAService.
	/// </summary>
	public class Job
	{
		public Int64 Id { get; set; }

		public Guid ProjectId { get; set; }

		public Guid EnvironmentId { get; set; }

		public Guid ProjectReleaseId { get; set; }

		/// <summary>
		/// The id from the transfert check, this job was created by, null if it was a restarted job
		/// </summary>
		public Guid? TransferCheckId { get; set; }

		public Guid? MarkeForProcessing { get; set; }

		public string ServiceId { get; set; }

		/// <summary>
		/// True, if this job was restarted sometime
		/// </summary>
		public bool WasAlreadyRestarted { get; set; }

		/// <summary>
		/// The orginal Job id, if this job is the result of a restart
		/// </summary>
		public Int64? RestartedFromJobId { get; set; }

		public String BackUpPath { get; set; }

		public Int64 ToBeProcessedBytes { get; set; }

		public DateTime Created { get; set; }

		public DateTime? Loaded { get; set; }

		public DateTime? Started { get; set; }

		public DateTime? Ended { get; set; }

		public JobStatus Status { get; set; }

		public string CommentOnStatus { get; set; }

		public Boolean Deleted { get; set; }




		public virtual Project Project { get; set; }

		public virtual Environment Environment { get; set; }

		public virtual ProjectRelease Release { get; set; }

		public virtual MSAServiceTransferCheck TransferCheck { get; set; }

		public virtual ICollection<JobStep> JobSteps { get; set; }

		public virtual ICollection<JobPKInfo> PKInfos { get; set; }

		public virtual ICollection<LogEntry> Logs { get; set; }



		public Job()
		{
			this.Status = JobStatus.NotStarted;
		}
	}
}