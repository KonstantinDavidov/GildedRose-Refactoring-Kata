using GildedRoseRefactoringKata.ProductStrategies;
using System.Collections.Generic;

namespace GildedRoseRefactoringKata
{
	public class GildedRose
	{
		private readonly IList<Item> _items;

		public GildedRose(IList<Item> items)
		{
			_items = items;
		}

		public void UpdateQuality()
		{
			foreach (var item in _items)
			{
				var strategyExecutor = new StrategyExecutor(item);
				strategyExecutor.Execute(item);
			}
		}
	}
}
