using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.PaddedArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.PaddedArmors
{
    public class PaddedArmorPlusOneTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new PaddedArmorPlusOne();

            // Act

            // Assert
            Assert.Equal("+1 Padded Armor", armor.Name);
            Assert.Equal(12, armor.BaseArmorValue);
            Assert.Equal(8, armor.Weight);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
    }
}