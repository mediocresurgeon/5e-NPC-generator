using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.PaddedArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.PaddedArmors
{
    public class PaddedArmorPlusTwoTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new PaddedArmorPlusTwo();

            // Act

            // Assert
            Assert.Equal("+2 Padded Armor", armor.Name);
            Assert.Equal(13, armor.BaseArmorValue);
            Assert.Equal(8, armor.Weight);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}