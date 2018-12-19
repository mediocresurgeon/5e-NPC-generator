using System;
using DungeonsAndDragons5e.AbilityChecks;
using DungeonsAndDragons5e.AbilityScores;
using Moq;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests.AbilityChecks
{
    public class AbilityCheckTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullAbilityScore_Throws()
        {
            // Arrange
            Action constructor = () => new AbilityCheck(null);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_Arg_Property()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            var abilityCheck = new AbilityCheck(abilityScore);

            // Act
            var result = abilityCheck.AbilityScore;

            // Assert
            Assert.Same(abilityScore, result);
        }
        #endregion


        #region AddModifier
        [Fact]
        public void AddModifier_Null_Throws()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            var abilityCheck = new AbilityCheck(abilityScore);

            // Act
            Action addModifier = () => abilityCheck.AddModifier(null);

            // Assert
            Assert.Throws<ArgumentNullException>(addModifier);
        }
        #endregion

        #region GetTotal
        [Fact]
        public void GetTotal_DefaultConfig_0()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            var abilityCheck = new AbilityCheck(abilityScore);

            // Act
            var result = abilityCheck.GetTotal();

            // Assert
            Assert.Equal(0, result);
            Mock.Get(abilityScore).Verify(s => s.Modifer);
        }


        [Fact]
        public void GetTotal_AbilityModifierIn_AbilityModifierOut()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(s => s.Modifer)
                            .Returns(-5);
            var abilityCheck = new AbilityCheck(mockAbilityScore.Object);

            // Act
            var result = abilityCheck.GetTotal();

            // Assert
            Assert.Equal(-5, result);
        }


        [Fact]
        public void GetTotal_MultipleModifiers_SumsCorrectly()
        {
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(s => s.Modifer)
                            .Returns(1);
            var abilityCheck = new AbilityCheck(mockAbilityScore.Object);
            abilityCheck.AddModifier(() => 2);
            abilityCheck.AddModifier(() => 5);

            // Act
            var result = abilityCheck.GetTotal();

            // Assert
            Assert.Equal(8, result);
        }
        #endregion
    }
}