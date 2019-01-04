using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.HideArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.HideArmors
{
    public class HideArmorPlusTwoTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new HideArmorPlusTwo();

            // Act

            // Assert
            Assert.Equal("+2 Hide Armor", armor.Name);
            Assert.Equal(14, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(12, armor.Weight);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}