using System;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityScores;
using Moq;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests.AbilityChecks.Skills
{
    public class SkillTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullAbilityScore_Throws()
        {
            // Arrange
            IAbilityScore abilityScore = null;
            Func<byte> proficiencyBonus = () => 2;

            // Act
            Action constructor = () => new Skill(abilityScore, proficiencyBonus);

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
            Action constructor = () => new Skill(abilityScore, proficiencyBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void IsProficient_DefaultConfig_False()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;
            var skill = new Skill(abilityScore, proficiencyBonus);

            // Act
            var result = skill.IsProficient;

            // Assert
            Assert.False(result);
        }
        #endregion

        #region GetTotal
        [Theory]
        [InlineData(false, 2, 0)]
        [InlineData(true,  2, 2)]
        [InlineData(false, 6, 0)]
        [InlineData(true,  6, 6)]
        public void IsProficient_TogglesProficiencyBonus(bool isProficient, byte proficiencyBonus, sbyte expectedTotal)
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            Func<byte> prof = () => proficiencyBonus;
            var skill = new Skill(abilityScore, prof) {
                IsProficient = isProficient
            };

            // Act
            var result = skill.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, result);
        }
        #endregion
    }
}
