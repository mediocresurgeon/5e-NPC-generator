using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.PaddedArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.PaddedArmors
{
    public class PaddedArmorEnhancedTest
    {
        #region Constructor
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void Constructor_InvalidEnhancementBonus_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action constructor = () => new PaddedArmorEnhanced(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Fact]
        public void DefaultProperties_PlusOne()
        {
            // Arrange
            var armor = new PaddedArmorEnhanced(1);

            // Act

            // Assert
            Assert.Equal("+1 Padded Armor", armor.Name);
            Assert.Equal(12, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusTwo()
        {
            // Arrange
            var armor = new PaddedArmorEnhanced(2);

            // Act

            // Assert
            Assert.Equal("+2 Padded Armor", armor.Name);
            Assert.Equal(13, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusThree()
        {
            // Arrange
            var armor = new PaddedArmorEnhanced(3);

            // Act

            // Assert
            Assert.Equal("+3 Padded Armor", armor.Name);
            Assert.Equal(14, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
        #endregion
    }
}