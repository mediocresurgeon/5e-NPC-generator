using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors.Core;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core
{
    public class EnhancementEnchantmentTest
    {
        #region GetRarity
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void GetRarity_BadArg_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action getRarity = () => EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(getRarity);
        }


        [Fact]
        public void GetRarity_PlusOne_Rare()
        {
            // Arrange
            byte enhancementBonus = 1;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.Rare, result);
        }


        [Fact]
        public void GetRarity_PlusTwo_Rare()
        {
            // Arrange
            byte enhancementBonus = 2;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.VeryRare, result);
        }


        [Fact]
        public void GetRarity_PlusThree_Rare()
        {
            // Arrange
            byte enhancementBonus = 3;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.Legendary, result);
        }
        #endregion
    }
}