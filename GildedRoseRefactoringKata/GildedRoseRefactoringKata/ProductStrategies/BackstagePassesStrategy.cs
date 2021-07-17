using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class BackstagePassesStrategy : BaseProductStrategy
	{
		public override void Execute(Item item)
		{
			//Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
			if (item.SellIn <= 5)
				IncreaseQuality(item, 3);
			else if (item.SellIn <= 10)
				IncreaseQuality(item, 2);
			else
				IncreaseQuality(item);

			DecreaseSellIn(item);

			//Quality drops to 0 after the concert
			if (item.SellIn < BusinessLogicConfiguration.SellInExpiredValue)
				ResetQuality(item);
		}
	}
}
