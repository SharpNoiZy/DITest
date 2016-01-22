using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class MSAService
	{
		public string Id { get; set; }

		public Guid? EnvironmentId { get; set; }

		public int MaxThreadCount { get; set; }

		/// <summary>
		/// This is the delay between job searches, given in seconds
		/// </summary>
		public int DelayBetweenJobSearches { get; set; }

		/// <summary>
		/// Should be every 10 sec. the case, is it not, the Windows service is not running or dead
		/// </summary>
		public DateTime LastCommandCheck { get; set; }

		/// <summary>
		/// This flag shows if the Service is watching and working on jobs, can also be false even though the Windows Service is up and running
		/// </summary>
		public bool IsWorkingOnJobs { get; set; }




		public virtual Environment Environment { get; set; }

		public virtual ICollection<MSAServiceTransferCheck> TransferCheck { get; set; }
	}
}