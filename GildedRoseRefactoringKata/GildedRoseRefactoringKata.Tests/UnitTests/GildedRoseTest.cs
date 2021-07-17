using System.Collections.Generic;
using GildedRoseRefactoringKata.Constants;
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
		[TestCase(BusinessLogicConfiguration.AgedBrie, 100, BusinessLogicConfiguration.MinQuality, BusinessLogicConfiguration.MaxQuality)]
		[TestCase(BusinessLogicConfiguration.BackstagePasses, 100, BusinessLogicConfiguration.MinQuality, BusinessLogicConfiguration.MaxQuality)]
		public void Quality_should_not_be_more_than_50(string productName, int sellIn, int quality, int expectedQuality)
		{
			var items = new List<Item>
			{
				new Item { Name = productName, SellIn = sellIn, Quality = quality },
			};
			var app = new GildedRose(items);

			for (var i = 0; i < 100; i++)
			{
				app.UpdateQuality();
			}

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_increased_by_2_if_between_5_and_10_days_Backstage([Range(6, 10)] int initSellIn)
		{
			const int initQuality = 0;
			const int expectedQuality = 2;

			var items = new List<Item>
			{
				new Item { Name = BusinessLogicConfiguration.BackstagePasses, SellIn = initSellIn, Quality = initQuality },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_increased_by_3_if_less_than_5days_Backstage([Range(1, 5)] int initSellIn)
		{
			const int initQuality = 0;
			const int expectedQuality = 3;

			var items = new List<Item>
			{
				new Item { Name = BusinessLogicConfiguration.BackstagePasses, SellIn = initSellIn, Quality = initQuality },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}

		[Test]
		public void Quality_should_be_0_if_concert_happened_Backstage()
		{
			const int expectedQuality = BusinessLogicConfiguration.MinQuality;
			const int initSellIn = 0;
			const int initQuality = 5;

			var items = new List<Item>
			{
				new Item { Name = BusinessLogicConfiguration.BackstagePasses, SellIn = initSellIn, Quality = initQuality },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}
		
		[Test]
		[TestCase(5, BusinessLogicConfiguration.LegendaryItemQuality, BusinessLogicConfiguration.LegendaryItemQuality)]
		[TestCase(0, BusinessLogicConfiguration.LegendaryItemQuality, BusinessLogicConfiguration.LegendaryItemQuality)]
		[TestCase(-1, BusinessLogicConfiguration.LegendaryItemQuality, BusinessLogicConfiguration.LegendaryItemQuality)]
		public void Quality_should_not_be_decreased_Sulfuras(int sellIn, int quality, int expectedQuality)
		{
			var items = new List<Item>
			{
				new Item { Name = BusinessLogicConfiguration.Sulfuras, SellIn = sellIn, Quality = quality },
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}

		/// <summary>
		/// "Aged Brie" actually increases in Quality the older it gets
		/// </summary>
		[Test]
		[TestCase(5, 5, 6)]
		[TestCase(0, 5, 7)]
		[TestCase(-1, 5, 7)]
		public void Aged_Brie_should_increases_quality_the_older_it_gets(int sellIn, int quality, int expectedQuality)
		{
			var items = new List<Item> { new Item { Name = BusinessLogicConfiguration.AgedBrie, SellIn = sellIn, Quality = quality } };
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}

		[Test]
		[TestCase(5, 5, 3)]
		[TestCase(0, 5, 1)]
		[TestCase(-1, 5, 1)]
		[TestCase(-1, 1, 0)]
		public void Conjured_should_decrease_quality_double_rate(int sellIn, int quality, int expectedQuality)
		{
			var items = new List<Item> { new Item { Name = BusinessLogicConfiguration.Conjured, SellIn = sellIn, Quality = quality } };
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.AreEqual(expectedQuality, items[0].Quality);
		}
	}
}
