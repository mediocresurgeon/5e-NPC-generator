using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.SavingThrows;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.SavingThrows
{
    public class SavingThrowsSectionTest
    {
        #region Test Setup
        public SavingThrowsSectionTest()
        {
            this.ProficiencyBonus = () => 2;

            var mockAbilityScoreSection = new Mock<IAbilityScoresSection>();
            mockAbilityScoreSection.Setup(s => s.Strength)
                                   .Returns(Mock.Of<IAbilityScore>());
            mockAbilityScoreSection.Setup(s => s.Dexterity)
                                   .Returns(Mock.Of<IAbilityScore>());
            mockAbilityScoreSection.Setup(s => s.Constitution)
                                   .Returns(Mock.Of<IAbilityScore>());
            mockAbilityScoreSection.Setup(s => s.Intelligence)
                                   .Returns(Mock.Of<IAbilityScore>());
            mockAbilityScoreSection.Setup(s => s.Wisdom)
                                   .Returns(Mock.Of<IAbilityScore>());
            mockAbilityScoreSection.Setup(s => s.Charisma)
                                   .Returns(Mock.Of<IAbilityScore>());
            this.AbilityScores = mockAbilityScoreSection.Object;
        }

        private IAbilityScoresSection AbilityScores { get; }

        private Func<byte> ProficiencyBonus { get; }
        #endregion

        #region
        [Fact]
        public void Constructor_DefaultConfig()
        {
            // Arrange
            var savingThrowsSection = new SavingThrowsSection(AbilityScores, ProficiencyBonus);

            // Act

            // Assert
            Assert.IsType<SavingThrow>(savingThrowsSection.Strength);
            Assert.IsType<SavingThrow>(savingThrowsSection.Dexterity);
            Assert.IsType<SavingThrow>(savingThrowsSection.Constitution);
            Assert.IsType<SavingThrow>(savingThrowsSection.Intelligence);
            Assert.IsType<SavingThrow>(savingThrowsSection.Wisdom);
            Assert.IsType<SavingThrow>(savingThrowsSection.Charisma);
        }
        #endregion
    }
}
