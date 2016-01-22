using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class XPathDbEntry
	{
		public string Id { get; set; }

		public string BMS_2_8_Xpath { get; set; }

		public int BMS_2_8_Order { get; set; }

		public string BMS_2_8_Class { get; set; }

		public string BMS_3_1_Xpath { get; set; }

		public int BMS_3_1_Order { get; set; }

		public string BMS_3_1_Class { get; set; }
	}
}