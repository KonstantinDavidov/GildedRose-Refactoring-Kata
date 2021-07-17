using System;
using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class StrategyExecutor
	{
		private readonly BaseProductStrategy _currentStrategy;

		public StrategyExecutor(Item item)
		{
			if (item is null)
				throw new ArgumentNullException(nameof(item));

			switch (item.Name)
			{
				case BusinessLogicConfiguration.AgedBrie:
					_currentStrategy = new AgedBrieStrategy();
					break;
				case BusinessLogicConfiguration.Sulfuras:
					_currentStrategy = new SulfurasStrategy();
					break;
				case BusinessLogicConfiguration.BackstagePasses:
					_currentStrategy = new BackstagePassesStrategy();
					break;
				case BusinessLogicConfiguration.Conjured:
					_currentStrategy = new ConjuredStrategy();
					break;
				default:
					_currentStrategy = new CommonItemStrategy();
					break;
			}
		}

		public void Execute(Item item)
		{
			if (item is null)
				throw new ArgumentNullException(nameof(item));

			_currentStrategy.Execute(item);
		}
	}
}
