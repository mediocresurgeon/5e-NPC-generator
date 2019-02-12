using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Weapons.Core.Longbows;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core.Longbows
{
    public class LongbowEnhancedTest
    {
        #region Constructor
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void Constructor_BadArg_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action constructor = () => new LongbowEnhanced(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Fact]
        public void DefaultProperties_PlusOne()
        {
            // Arrange
            var weapon = new LongbowEnhanced(1);

            // Act

            // Assert
            Assert.Equal("+1 Longbow", weapon.Name);
            Assert.Equal(Rarity.Uncommon, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusTwo()
        {
            // Arrange
            var weapon = new LongbowEnhanced(2);

            // Act

            // Assert
            Assert.Equal("+2 Longbow", weapon.Name);
            Assert.Equal(Rarity.Rare, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }


        [Fact]
        public void DefaultProperties_PlusThree()
        {
            // Arrange
            var weapon = new LongbowEnhanced(3);

            // Act

            // Assert
            Assert.Equal("+3 Longbow", weapon.Name);
            Assert.Equal(Rarity.VeryRare, weapon.Rarity);
            Assert.False(weapon.MarketValue.HasValue);
            Assert.False(weapon.RequiresAtunement);
        }
        #endregion
    }
}
