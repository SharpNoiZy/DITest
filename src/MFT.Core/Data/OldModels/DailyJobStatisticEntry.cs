using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class DailyJobStatisticEntry : EntityBase
	{
		public DateTime Day { get; set; }

		public Guid EnvironmentId { get; set; }

		public string ServiceId { get; set; }

		public string CustomerId { get; set; }

		public Guid ProjectId { get; set; }

		public int ReleaseNr { get; set; }

		public int ExecutedJobs { get; set; }

		public int WarnedJobs { get; set; }

		public int FailedJobs { get; set; }

		public int AverageInputSize { get; set; }

		public double AverageWaitingTime { get; set; }

		public double AverageExecutionTime { get; set; }
	}
}