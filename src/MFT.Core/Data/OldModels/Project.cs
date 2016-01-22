using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class Project : EntityBase
	{
		public string CustomerId { get; set; }

		public ProjectConnectivityType ConnectivityType { get; set; }

		public ProjectDirection Direction { get; set; }

		public ProjectTransmissionFormat InputFormat { get; set; }

		public ProjectTransmissionFormat OutputFormat { get; set; }

		public String Name { get; set; }

		public ProjectPriority Priority { get; set; }

		public string BuildDirectoryRoot { get; set; }

		public string ErrorMailRecipients { get; set; }

		public DateTime CreationDate { get; set; }




		public virtual Customer Customer { get; set; }

		public virtual ICollection<ProjectRelease> Releases { get; set; }

		public virtual ICollection<Job> Jobs { get; set; }

		public virtual ICollection<ProjectKnownExitCode> KnownExitCodes { get; set; }

		public virtual ICollection<ProjectEnvironmentConfig> EnvironmentConfigs { get; set; }
	}
}