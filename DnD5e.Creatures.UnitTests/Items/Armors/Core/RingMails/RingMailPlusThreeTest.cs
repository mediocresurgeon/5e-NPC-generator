using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.RingMails;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.RingMails
{
    public class RingMailPlusThreeTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new RingMailPlusThree();

            // Act

            // Assert
            Assert.Equal("+3 Ring Mail", armor.Name);
            Assert.Equal(17, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(40, armor.Weight);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}