using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Weapons.Core.Daggers;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core.Daggers
{
    public class DaggerEnhancedTest
    {
        #region Constructor
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void Constructor_BadArg_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action constructor = () => new DaggerEnhanced(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Fact]
        public void DefaultProperties_PlusOne()
        {
            // Arrange
            var weapon = new DaggerEnhanced(1);

            // Act

            // Assert
            Assert.Equal("+1 Dagger", weapon.Name);
            Assert.Equal(Rarity.Uncommon, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusTwo()
        {
            // Arrange
            var weapon = new DaggerEnhanced(2);

            // Act

            // Assert
            Assert.Equal("+2 Dagger", weapon.Name);
            Assert.Equal(Rarity.Rare, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusThree()
        {
            // Arrange
            var weapon = new DaggerEnhanced(3);

            // Act

            // Assert
            Assert.Equal("+3 Dagger", weapon.Name);
            Assert.Equal(Rarity.VeryRare, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }
        #endregion
    }
}