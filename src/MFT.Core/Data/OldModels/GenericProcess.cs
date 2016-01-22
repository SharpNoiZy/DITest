namespace MFT.Core.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;


	public class GenericProcess : EntityBase
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string UsedLanguage { get; set; }

		public string BuildsDirectory { get; set; }
	}
}