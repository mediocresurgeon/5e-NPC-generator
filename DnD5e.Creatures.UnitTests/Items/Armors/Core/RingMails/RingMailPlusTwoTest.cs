using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.RingMails;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.RingMails
{
    public class RingMailPlusTwoTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new RingMailPlusTwo();

            // Act

            // Assert
            Assert.Equal("+2 Ring Mail", armor.Name);
            Assert.Equal(16, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(40, armor.Weight);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}