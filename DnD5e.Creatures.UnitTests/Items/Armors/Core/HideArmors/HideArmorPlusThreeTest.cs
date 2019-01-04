using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.HideArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.HideArmors
{
    public class HideArmorPlusThreeTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new HideArmorPlusThree();

            // Act

            // Assert
            Assert.Equal("+3 Hide Armor", armor.Name);
            Assert.Equal(15, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(12, armor.Weight);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}
