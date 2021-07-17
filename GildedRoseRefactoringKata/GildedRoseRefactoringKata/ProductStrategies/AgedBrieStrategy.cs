using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class AgedBrieStrategy : BaseProductStrategy
	{
		public override void Execute(Item item)
		{
			//"Aged Brie" actually increases in Quality the older it gets.
			//So, system should never decrease quality for this type of product.
			IncreaseQuality(item);
			DecreaseSellIn(item);

			if (item.SellIn < BusinessLogicConfiguration.SellInExpiredValue)
				IncreaseQuality(item);
		}
	}
}
