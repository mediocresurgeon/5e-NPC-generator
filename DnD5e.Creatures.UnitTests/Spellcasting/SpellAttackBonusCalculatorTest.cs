using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Spellcasting
{
    public class SpellAttackBonusCalculatorTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = null;
            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            // Act
            Action constructor = () => new SpellAttackBonusCalculator(proficiencyBonus, spellcastingStat);

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
            Action constructor = () => new SpellAttackBonusCalculator(proficiencyBonus, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Total
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(4, 3, 7)]
        public void Total_WithoutMod_WithoutOverride(byte prof, sbyte ability, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new SpellAttackBonusCalculator(proficiencyBonus, mockAbilityScore.Object);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, 0, 1, 2)]
        [InlineData(0, 1, 1, 2)]
        [InlineData(4, 3, 1, 8)]
        public void Total_WithMod_WithoutOverride(byte prof, sbyte ability, sbyte mod, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new SpellAttackBonusCalculator(proficiencyBonus, mockAbilityScore.Object);
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(4, 3, 6, 6)]
        public void Total_WithoutMod_WithOverride(byte prof, sbyte ability, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new SpellAttackBonusCalculator(proficiencyBonus, mockAbilityScore.Object);
            attackBonusCalc.Total = assignment;

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 1, 0, 1)]
        [InlineData(1, 0, 1, 0, 1)]
        [InlineData(0, 1, 1, 0, 1)]
        [InlineData(4, 3, 1, 6, 7)]
        public void Total_WithMod_WithOverride(byte prof, sbyte ability, sbyte mod, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);

            var attackBonusCalc = new SpellAttackBonusCalculator(proficiencyBonus, mockAbilityScore.Object);
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