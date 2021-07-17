using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRoseRefactoringKata.Tests.UnitTests
{
	[TestFixture]
	public class GildedRoseTest
	{
		[Test]
		public void foo()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("foo", Items[0].Name);
		}
	}
}
