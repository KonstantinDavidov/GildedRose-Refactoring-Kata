using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRoseRefactoringKata.Tests.UnitTests
{
	[TestFixture]
	public class GildedRoseTest
	{
		[Test]
		public void Quality_should_not_be_negative()
		{
			var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual("foo", items[0].Name);
			Assert.AreEqual(-1, items[0].SellIn);
			Assert.AreEqual(0, items[0].Quality);
		}

		[Test]
		public void Quality_should_decrease_two_time_faster()
		{
			var items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 6 } };
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(-2, items[0].SellIn);
			Assert.AreEqual(4, items[0].Quality);
		}

		[Test]
		public void Quality_should_not_be_more_than_50_AgedBrie()
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.AgedBrie, SellIn = 0, Quality = 0 },
			};
			var app = new GildedRose(items);

			for (var i = 0; i < 100; i++)
			{
				items[0].SellIn -= 1;
				app.UpdateQuality();
			}

			Assert.AreEqual(50, items[0].Quality);
		}

		[Test]
		public void Quality_should_not_be_more_than_50_Backstage()
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.BackstagePasses, SellIn = 100, Quality = 0 },
			};
			var app = new GildedRose(items);

			for (var i = 0; i < 50; i++)
			{
				items[0].SellIn -= 1;
				app.UpdateQuality();
			}

			Assert.AreEqual(50, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_increased_by_2_if_between_5_and_10_days_Backstage([Range(6, 10)] int days)
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.BackstagePasses, SellIn = days, Quality = 0 },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(2, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_increased_by_3_if_less_than_5days_Backstage([Range(1, 5)] int days)
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.BackstagePasses, SellIn = days, Quality = 0 },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(3, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_0_if_concert_happened_Backstage()
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.BackstagePasses, SellIn = 0, Quality = 5 },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(0, items[0].Quality);
		}

		[Test]
		[TestCase(-5)]
		[TestCase(5)]
		public void Quality_should_not_be_decreased_Sulfuras(int days)
		{
			var items = new List<Item>
			{
				new Item { Name = Constants.Sulfuras, SellIn = days, Quality = 80 },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(80, items[0].Quality);
		}

		/// <summary>
		/// "Aged Brie" actually increases in Quality the older it gets
		/// </summary>
		[Test]
		public void Aged_Brie_should_increases_quality_the_older_it_gets()
		{
			var items = new List<Item> { new Item { Name = Constants.AgedBrie, SellIn = -5, Quality = 0 } };
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(2, items[0].Quality);

			app.UpdateQuality();

			Assert.AreEqual(4, items[0].Quality);
		}
	}
}
