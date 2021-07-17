using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace GildedRoseRefactoringKata.Tests.AcceptanceTests
{
	[UseReporter(typeof(DiffReporter))]
	[TestFixture]
	public class ApprovalTest
	{
		[Test]
		public void ThirtyDays()
		{
			var fakeOutput = new StringBuilder();

			Console.SetOut(new StringWriter(fakeOutput));
			Console.SetIn(new StringReader("a\n"));

			Program.Main(new string[] { });
			var output = fakeOutput.ToString();

			Approvals.Verify(output);
		}
	}
}
