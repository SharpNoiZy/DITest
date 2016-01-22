using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ProjectKnownExitCode : EntityBase
	{
		public Guid ProjectId { get; set; }

		public int ExitCode { get; set; }

		public string Comment { get; set; }




		public virtual Project Project { get; set; }
	}
}