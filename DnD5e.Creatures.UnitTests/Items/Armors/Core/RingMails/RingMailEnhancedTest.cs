using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core.RingMails;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.RingMails
{
    public class RingMailEnhancedTest
    {
        #region Constructor
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void Constructor_InvalidEnhancementBonus_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action constructor = () => new RingMailEnhanced(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Fact]
        public void DefaultProperties_PlusOne()
        {
            // Arrange
            var armor = new RingMailEnhanced(1);

            // Act

            // Assert
            Assert.Equal("+1 Ring Mail", armor.Name);
            Assert.Equal(15, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Rare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusTwo()
        {
            // Arrange
            var armor = new RingMailEnhanced(2);

            // Act

            // Assert
            Assert.Equal("+2 Ring Mail", armor.Name);
            Assert.Equal(16, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.VeryRare, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusThree()
        {
            // Arrange
            var armor = new RingMailEnhanced(3);

            // Act

            // Assert
            Assert.Equal("+3 Ring Mail", armor.Name);
            Assert.Equal(17, armor.BaseArmorValue);
            Assert.False(armor.MarketValue.HasValue);
            Assert.Equal(Rarity.Legendary, armor.Rarity);
            Assert.False(armor.RequiresAtunement);
        }
        #endregion
    }
}