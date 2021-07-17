using GildedRoseRefactoringKata.Constants;

namespace GildedRoseRefactoringKata.ProductStrategies
{
	public abstract class BaseProductStrategy
	{
		private const int MaxQuality = BusinessLogicConfiguration.MaxQuality;

		public abstract void Execute(Item item);

		protected void DecreaseQuality(Item item)
		{
			if (IsMinimumQuality(item))
				return;

			item.Quality -= BusinessLogicConfiguration.StandardDecreaseQualityStep;
		}

		protected void DecreaseQuality(Item item, int customValue)
		{
			if (IsMinimumQuality(item))
				return;

			if (IsMinimumQuality(item, customValue))
			{
				ResetQuality(item);
				return;
			}

			item.Quality -= customValue;
		}

		protected void IncreaseQuality(Item item)
		{
			if (IsMaximumQuality(item))
				item.Quality += BusinessLogicConfiguration.StandardIncreaseQualityStep;
		}

		protected void IncreaseQuality(Item item, int customValue)
		{
			if (IsMaximumQuality(item, customValue))
			{
				item.Quality = MaxQuality;
				return;
			}

			item.Quality += customValue;
		}

		protected void ResetQuality(Item item) => item.Quality = BusinessLogicConfiguration.MinQuality;

		protected void DecreaseSellIn(Item item) => item.SellIn -= BusinessLogicConfiguration.SellInDecreaseStep;

		private static bool IsMinimumQuality(Item item) => item.Quality <= BusinessLogicConfiguration.MinQuality;

		private static bool IsMinimumQuality(Item item, int customValue) => item.Quality - customValue <= BusinessLogicConfiguration.MinQuality;

		private static bool IsMaximumQuality(Item item) => item.Quality < MaxQuality;

		private static bool IsMaximumQuality(Item item, int customValue) => item.Quality + customValue >= MaxQuality;
	}
}
