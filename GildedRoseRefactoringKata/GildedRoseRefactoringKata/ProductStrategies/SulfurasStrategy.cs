namespace GildedRoseRefactoringKata.ProductStrategies
{
	public class SulfurasStrategy : BaseProductStrategy
	{
		public override void Execute(Item item)
		{
			//The algorithm for update looks like: '"Sulfuras", being a legendary item, never has to be sold or decreases in Quality'
			//so, we don't need to do anything here.
		}
	}
}
