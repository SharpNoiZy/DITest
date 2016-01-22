using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Test.MFT.Integration.Helper
{
	[Collection("DI collection")]
	public abstract class SpecificationBase<TSubjectToTest> : IClassFixture<DatabaseFixture> where TSubjectToTest : class
	{
		private DatabaseFixture _dbFixture;

		private DependencyInjectionFixture _diFixture;




		protected TSubjectToTest _subjectToTest;


		public SpecificationBase()
		{
			Given();
			When();
		}

		protected virtual void Given() { }

		protected virtual void When() { }
	}
}
