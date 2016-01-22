using MFT.Core.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class LogEntry : EntityBase
	{
		/// <summary>
		/// The moment on which the entry was created
		/// </summary>
		public DateTime LoggedOn { get; set; }

		/// <summary>
		/// The log level for that Entry: [DEBUG], [INFO], [ERROR], [FATAL]
		/// </summary>
		public LogLevel Level { get; set; }

		/// <summary>
		/// The message
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// An optional exception text
		/// </summary>
		public string Exception { get; set; }

		public Int64? JobId { get; set; }

		public Guid? JobStepId { get; set; }




		public virtual Job Job { get; set; }

		public virtual JobStep JobStep { get; set; }
	}
}