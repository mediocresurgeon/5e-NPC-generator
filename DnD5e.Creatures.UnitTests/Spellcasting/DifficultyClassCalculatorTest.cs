using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Spellcasting
{
    public class DifficultyClassCalculatorTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = null;
            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            // Act
            Action constructor = () => new DifficultyClassCalculator(proficiencyBonus, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullSpellcastingStatBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = () => 2;
            IAbilityScore spellcastingStat = null;

            // Act
            Action constructor = () => new DifficultyClassCalculator(proficiencyBonus, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Total
        [Theory]
        [InlineData(0, 0,  8)]
        [InlineData(1, 0,  9)]
        [InlineData(0, 1,  9)]
        [InlineData(4, 3, 15)]
        public void Total_WithoutMod_WithoutOverride(byte prof, sbyte ability, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new DifficultyClassCalculator(proficiencyBonus, mockAbilityScore.Object);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 1,  9)]
        [InlineData(1, 0, 1, 10)]
        [InlineData(0, 1, 1, 10)]
        [InlineData(4, 3, 1, 16)]
        public void Total_WithMod_WithoutOverride(byte prof, sbyte ability, sbyte mod, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new DifficultyClassCalculator(proficiencyBonus, mockAbilityScore.Object);
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 13, 13)]
        [InlineData(1, 0, 13, 13)]
        [InlineData(0, 1, 13, 13)]
        [InlineData(4, 3, 13, 13)]
        public void Total_WithoutMod_WithOverride(byte prof, sbyte ability, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new DifficultyClassCalculator(proficiencyBonus, mockAbilityScore.Object);
            attackBonusCalc.Total = assignment;

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 1, 14, 15)]
        [InlineData(1, 0, 1, 14, 15)]
        [InlineData(0, 1, 1, 14, 15)]
        [InlineData(4, 3, 1, 14, 15)]
        public void Total_WithMod_WithOverride(byte prof, sbyte ability, sbyte mod, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new DifficultyClassCalculator(proficiencyBonus, mockAbilityScore.Object);
            attackBonusCalc.Total = assignment;
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}
