using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Attacks
{
    public class DamageBonusCalculatorTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullAbilityScore_Throws()
        {
            // Arrange
            Func<IAbilityScore> keyAbilityScore = null;

            // Act
            Action constructor = () => new DamageBonusCalculator(keyAbilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Total
        [Theory]
        [InlineData( 0, 0)]
        [InlineData(-1, -1)]
        [InlineData( 1, 1)]
        public void Total_NoMods_WithoutOverrides(sbyte abilityMod, sbyte expected)
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(abilityMod);

            var dmgBonusCalc = new DamageBonusCalculator(() => mockAbilityScore.Object);

            // Act
            var result = dmgBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData( 0, 1, 1)]
        [InlineData( 1, 0, 1)]
        [InlineData( 1, 1, 2)]
        public void Total_WithMods_WithoutOverrides(sbyte abilityMod, sbyte miscMod, sbyte expected)
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(abilityMod);

            var dmgBonusCalc = new DamageBonusCalculator(() => mockAbilityScore.Object);
            dmgBonusCalc.AddModifier(() => miscMod);

            // Act
            var result = dmgBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}