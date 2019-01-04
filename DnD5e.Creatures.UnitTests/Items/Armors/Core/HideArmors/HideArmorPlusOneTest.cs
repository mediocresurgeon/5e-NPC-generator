using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.HideArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.HideArmors
{
    public class HideArmorPlusOneTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new HideArmorPlusOne();

            // Act

            // Assert
            Assert.Equal("+1 Hide Armor", armor.Name);
            Assert.Equal(13, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(12, armor.Weight);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}
