using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class CommonItemStrategy : BaseProductStrategy
	{
		public override void Execute(Item item)
		{
			DecreaseSellIn(item);
			DecreaseQuality(item);

			//Once the sell by date has passed, Quality degrades twice as fast
			if (item.SellIn < BusinessLogicConfiguration.SellInExpiredValue)
				DecreaseQuality(item);
		}
	}
}
