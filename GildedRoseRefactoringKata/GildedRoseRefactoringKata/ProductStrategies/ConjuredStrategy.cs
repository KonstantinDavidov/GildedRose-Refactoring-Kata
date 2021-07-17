using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class ConjuredStrategy : BaseProductStrategy
	{
		public override void Execute(Item item)
		{
			DecreaseSellIn(item);

			//"Conjured" items degrade in Quality twice as fast as normal items.
			//So, if SellIn more or equals 0, then decrease by 2.
			//If SellIn less than 0, then decrease by 4.
			var decreaseStep = item.SellIn < BusinessLogicConfiguration.SellInExpiredValue 
				? BusinessLogicConfiguration.DoubleDecreaseQualityStep * 2
				: BusinessLogicConfiguration.StandardDecreaseQualityStep * 2;

			DecreaseQuality(item, decreaseStep);
		}
	}
}
