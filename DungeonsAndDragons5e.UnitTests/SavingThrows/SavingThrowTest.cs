using System;
using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.SavingThrows;
using Moq;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests.SavingThrows
{
    public class SavingThrowTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullAbilityScore_Throws()
        {
            // Arrange
            IAbilityScore abilityScore = null;
            Func<byte> proficiencyBonus = () => 2;

            // Act
            Action constructor = () => new SavingThrow(abilityScore, proficiencyBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            IAbilityScore abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = null;

            // Act
            Action constructor = () => new SavingThrow(abilityScore, proficiencyBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region GetTotal
        [Theory]
        [InlineData(-5, false, 2, -5)]
        [InlineData(-5, true,  2, -3)]
        [InlineData(-5, false, 6, -5)]
        [InlineData(-5, true,  6,  1)]
        [InlineData( 0, false, 2,  0)]
        [InlineData( 0, true,  2,  2)]
        [InlineData( 0, false, 6,  0)]
        [InlineData( 0, true,  6,  6)]
        [InlineData( 5, false, 2,  5)]
        [InlineData( 5, true,  2,  7)]
        [InlineData( 5, false, 6,  5)]
        [InlineData( 5, true,  6, 11)]
        public void GetTotal(sbyte abilityScoreModifier, bool isProficient, byte proficiencyBonus, sbyte expectedTotal)
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(s => s.Modifer)
                            .Returns(abilityScoreModifier);
            var savingThrow = new SavingThrow(mockAbilityScore.Object, () => proficiencyBonus) {
                IsProficient = isProficient
            };

            // Act
            var result = savingThrow.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, result);
        }
        #endregion
    }
}