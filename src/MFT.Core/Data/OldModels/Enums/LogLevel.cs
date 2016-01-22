using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models.Enums
{
	public enum LogLevel
	{
		/// <summary>
		///     Statements which are useful when you are still writing an application, and when you need a complete understanding of what/where your execution flow is.
		/// </summary>
		DEBUG,


		/// <summary>
		///     Should be used whenever there is information which will be very useful if something goes wrong, but does not indicate that anything has gone wrong.
		/// </summary>
		INFO,


		/// <summary>
		///	Should be used if the application want to warn about something, that sould someone pay attention to 
		/// </summary>
		WARNING,


		/// <summary>
		///	Errors which are not fatal, means the application can run without the faulty part, means maybe only a nice to have feature or something.
		/// </summary>
		ERROR,


		/// <summary>
		///	Fatal error means, the application can not continue to run, for example the login doesn't work anymore, so no user can login to your page.
		/// </summary>
		FATAL
	}
}
