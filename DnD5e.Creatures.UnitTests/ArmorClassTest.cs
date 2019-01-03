using System;
using DnD5e.Creatures.AbilityScores;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests
{
    public class ArmorClassTest
    {

        #region Constructor
        [Fact]
        public void Constructor_NullAbilityScore_Throws()
        {
            // Arrange
            IAbilityScore dex = null;

            // Act
            Action constructor = () => new ArmorClass(dex);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region GetTotal
        [Fact]
        public void GetTotal_DefaultConfiguration_10()
        {
            // Arrange
            var dex = Mock.Of<IAbilityScore>();
            var ac = new ArmorClass(dex);

            // Act
            var result = ac.GetTotal();

            // Assert
            Assert.Equal(10, result);
        }


        [Theory]
        // Base cases: dex modifier, no armor, no shields
        [InlineData(-5, new byte[] { }, new byte[] { }, new sbyte[] { },  5)]
        [InlineData(-1, new byte[] { }, new byte[] { }, new sbyte[] { },  9)]
        [InlineData( 0, new byte[] { }, new byte[] { }, new sbyte[] { }, 10)]
        [InlineData( 1, new byte[] { }, new byte[] { }, new sbyte[] { }, 11)]
        [InlineData( 5, new byte[] { }, new byte[] { }, new sbyte[] { }, 15)]
        // dex modifier, no armor, shield
        [InlineData(-5, new byte[] { }, new byte[] { }, new sbyte[] { 2 },  7)]
        [InlineData(-1, new byte[] { }, new byte[] { }, new sbyte[] { 2 }, 11)]
        [InlineData( 0, new byte[] { }, new byte[] { }, new sbyte[] { 2 }, 12)]
        [InlineData( 1, new byte[] { }, new byte[] { }, new sbyte[] { 2 }, 13)]
        [InlineData( 5, new byte[] { }, new byte[] { }, new sbyte[] { 2 }, 17)]
        // dex modifier, light armor, no shields
        [InlineData(-5, new byte[] { }, new byte[] { 12 }, new sbyte[] { },  7)]
        [InlineData(-1, new byte[] { }, new byte[] { 12 }, new sbyte[] { }, 11)]
        [InlineData( 0, new byte[] { }, new byte[] { 12 }, new sbyte[] { }, 12)]
        [InlineData( 1, new byte[] { }, new byte[] { 12 }, new sbyte[] { }, 13)]
        [InlineData( 5, new byte[] { }, new byte[] { 12 }, new sbyte[] { }, 17)]
        // dex modifier, light armor, shield
        [InlineData(-5, new byte[] { }, new byte[] { 12 }, new sbyte[] { 2 },  9)]
        [InlineData(-1, new byte[] { }, new byte[] { 12 }, new sbyte[] { 2 }, 13)]
        [InlineData( 0, new byte[] { }, new byte[] { 12 }, new sbyte[] { 2 }, 14)]
        [InlineData( 1, new byte[] { }, new byte[] { 12 }, new sbyte[] { 2 }, 15)]
        [InlineData( 5, new byte[] { }, new byte[] { 12 }, new sbyte[] { 2 }, 19)]
        // dex modifier, medium armor, no shields
        [InlineData(-5, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { },  9)]
        [InlineData(-1, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { }, 13)]
        [InlineData( 0, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { }, 14)]
        [InlineData( 1, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { }, 15)]
        [InlineData( 5, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { }, 16)]
        // dex modifier, medium armor, shield
        [InlineData(-5, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { 2 }, 11)]
        [InlineData(-1, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { 2 }, 15)]
        [InlineData( 0, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { 2 }, 16)]
        [InlineData( 1, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { 2 }, 17)]
        [InlineData( 5, new byte[] { 2 }, new byte[] { 14 }, new sbyte[] { 2 }, 18)]
        // dex modifier, heavy armor, no shields
        [InlineData(-5, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { }, 11)]
        [InlineData(-1, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { }, 15)]
        [InlineData( 0, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { }, 16)]
        [InlineData( 1, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { }, 16)]
        [InlineData( 5, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { }, 16)]
        // dex modifier, heavy armor, shield
        [InlineData(-5, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { 2 }, 13)]
        [InlineData(-1, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { 2 }, 17)]
        [InlineData( 0, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { 2 }, 18)]
        [InlineData( 1, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { 2 }, 18)]
        [InlineData( 5, new byte[] { 0 }, new byte[] { 16 }, new sbyte[] { 2 }, 18)]
        public void GetTotal_MaxDex(sbyte   dexModifier,
                                    byte[]  maxDexBonuses,
                                    byte[]  baseArmorBonuses,
                                    sbyte[] modifiers,
                                    sbyte   expectedTotal)
        {
            // Arrange
            var mockDex = new Mock<IAbilityScore>();
            mockDex.Setup(d => d.Modifer)
                   .Returns(dexModifier);

            var ac = new ArmorClass(mockDex.Object);
            foreach (var maxDexBonus in maxDexBonuses)
            {
                ac.AddMaxDex(() => maxDexBonus);
            }
            foreach(var baseArmor in baseArmorBonuses)
            {
                ac.AddBase(() => baseArmor);
            }
            foreach(var modifier in modifiers)
            {
                ac.AddModifier(() => modifier);
            }

            // Act
            var result = ac.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, result);
        }
        #endregion
    }
}