using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.RingMails;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.RingMails
{
    public class RingMailPlusOneTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new RingMailPlusOne();

            // Act

            // Assert
            Assert.Equal("+1 Ring Mail", armor.Name);
            Assert.Equal(15, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(40, armor.Weight);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}
