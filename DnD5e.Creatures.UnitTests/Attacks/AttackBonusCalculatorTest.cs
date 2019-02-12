using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Attacks
{
    public class AttackBonusCalculatorTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = null;
            Func<IAbilityScore> keyAbilityScore = () => Mock.Of<IAbilityScore>();

            // Act
            Action constructor = () => new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullKeyAbilityScoreBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = () => 2;
            Func<IAbilityScore> keyAbilityScore = null;

            // Act
            Action constructor = () => new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);

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
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);

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
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);
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
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);
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
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);
            attackBonusCalc.Total = assignment;
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.Total;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region DefaultAttackBonus
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(4, 3, 7)]
        public void DefaultAttackBonus_WithoutMod_CorrectTotal(byte prof, sbyte ability, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);

            // Act
            var result = attackBonusCalc.DefaultAttackBonus();

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, 0, 1, 2)]
        [InlineData(0, 1, 1, 2)]
        [InlineData(4, 3, 1, 8)]
        public void DefaultAttackBonus_WithMod_CorrectTotal(byte prof, sbyte ability, sbyte mod, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);
            Func<IAbilityScore> keyAbilityScore = () => mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, keyAbilityScore);
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.DefaultAttackBonus();

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region SpecificAttackBonus()
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 1, 1, 1)]
        public void SpecificAttackBonus_WithoutMod_CorrectTotal(byte prof, sbyte ability, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);
            var abilityScore = mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, () => abilityScore);
            attackBonusCalc.Total = assignment;

            // Act
            var result = attackBonusCalc.SpecifiedAttackBonus();

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, 0, 1, 1)]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 1, 0, 1, 1)]
        [InlineData(0, 0, 1, 1, 2)]
        [InlineData(0, 1, 1, 1, 2)]
        [InlineData(1, 1, 1, 1, 2)]
        public void SpecificAttackBonus_WithMod_CorrectTotal(byte prof, sbyte ability, sbyte mod, sbyte assignment, sbyte expected)
        {
            // Arrange
            Func<byte> proficiencyBonus = () => prof;
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.SetupGet(ab => ab.Modifer)
                            .Returns(ability);
            var abilityScore = mockAbilityScore.Object;

            var attackBonusCalc = new AttackBonusCalculator(proficiencyBonus, () => abilityScore);
            attackBonusCalc.Total = assignment;
            attackBonusCalc.AddModifier(() => mod);

            // Act
            var result = attackBonusCalc.SpecifiedAttackBonus();

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}