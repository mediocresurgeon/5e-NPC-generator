using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.WonderousItems.Core;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.WonderousItems.Core
{
    public class BagOfHoldingTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var item = new BagOfHolding();

            // Act

            // Assert
            Assert.Equal("Bag of Holding", item.Name);
            Assert.Equal(Rarity.Uncommon, item.Rarity);
            Assert.False(item.RequiresAtunement);
            Assert.Equal(15, item.Weight);
            Assert.Null(item.MarketValue);
        }
    }
}