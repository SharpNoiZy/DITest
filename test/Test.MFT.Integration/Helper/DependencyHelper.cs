using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Test.MFT.Integration.Helper
{
	public static class DependencyHelper
	{
		public static ServiceCollection Services { get; set; } = new ServiceCollection();


		public static IServiceProvider Provider { get; set; }
	}
}