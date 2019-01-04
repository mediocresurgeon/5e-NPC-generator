using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.PaddedArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.PaddedArmors
{
    public class PaddedArmorPlusThreeTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new PaddedArmorPlusThree();

            // Act

            // Assert
            Assert.Equal("+3 Padded Armor", armor.Name);
            Assert.Equal(14, armor.BaseArmorValue);
            Assert.Equal(8, armor.Weight);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}