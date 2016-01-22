using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration
{
	public static class Helper
	{
		public static int GetUtcOffsetInMinutesByTimezoneId(string timezone_id)
		{
			var utc = DateTime.UtcNow;

			var zone = TimeZoneInfo.FindSystemTimeZoneById(timezone_id);
			var utc_offset = new DateTimeOffset(utc, TimeSpan.Zero);
			DateTimeOffset local_offset = utc_offset.ToOffset(zone.GetUtcOffset(utc_offset));

			return Convert.ToInt32(local_offset.Offset.TotalMinutes);
		}
	}
}