using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.HideArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.HideArmors
{
    public class HideArmorEnhancedTest
    {
        #region Constructor
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void Constructor_InvalidEnhancementBonus_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action constructor = () => new HideArmorEnhanced(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Fact]
        public void DefaultProperties_PlusOne()
        {
            // Arrange
            var armor = new HideArmorEnhanced(1);

            // Act

            // Assert
            Assert.Equal("+1 Hide Armor", armor.Name);
            Assert.Equal(13, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusTwo()
        {
            // Arrange
            var armor = new HideArmorEnhanced(2);

            // Act

            // Assert
            Assert.Equal("+2 Hide Armor", armor.Name);
            Assert.Equal(14, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusThree()
        {
            // Arrange
            var armor = new HideArmorEnhanced(3);

            // Act

            // Assert
            Assert.Equal("+3 Hide Armor", armor.Name);
            Assert.Equal(15, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
        #endregion
    }
}