using System;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityScores;
using Moq;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests.AbilityChecks.Skills
{
    public class SkillsSectionTest
    {
        #region Test Setup
        public SkillsSectionTest()
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

        #region Strength skills
        [Fact]
        public void Athletics_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Athletics);
            Assert.Same(this.AbilityScores.Strength, skillsSection.Athletics.AbilityScore);
        }
        #endregion

        #region Dexterity skills
        [Fact]
        public void Acrobatics_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Acrobatics);
            Assert.Same(this.AbilityScores.Dexterity, skillsSection.Acrobatics.AbilityScore);
        }


        [Fact]
        public void SleightOfHand_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.SleightOfHand);
            Assert.Same(this.AbilityScores.Dexterity, skillsSection.SleightOfHand.AbilityScore);
        }


        [Fact]
        public void Stealth_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Stealth);
            Assert.Same(this.AbilityScores.Dexterity, skillsSection.Stealth.AbilityScore);
        }
        #endregion

        #region Intelligence skills
        [Fact]
        public void Arcana_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Arcana);
            Assert.Same(this.AbilityScores.Intelligence, skillsSection.Arcana.AbilityScore);
        }


        [Fact]
        public void History_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.History);
            Assert.Same(this.AbilityScores.Intelligence, skillsSection.History.AbilityScore);
        }


        [Fact]
        public void Investigation_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Investigation);
            Assert.Same(this.AbilityScores.Intelligence, skillsSection.Investigation.AbilityScore);
        }


        [Fact]
        public void Nature_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Nature);
            Assert.Same(this.AbilityScores.Intelligence, skillsSection.Nature.AbilityScore);
        }


        [Fact]
        public void Religion_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Religion);
            Assert.Same(this.AbilityScores.Intelligence, skillsSection.Religion.AbilityScore);
        }
        #endregion

        #region Wisdom skills
        [Fact]
        public void AnimalHandling_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.AnimalHandling);
            Assert.Same(this.AbilityScores.Wisdom, skillsSection.AnimalHandling.AbilityScore);
        }


        [Fact]
        public void Insight_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Insight);
            Assert.Same(this.AbilityScores.Wisdom, skillsSection.Insight.AbilityScore);
        }


        [Fact]
        public void Medicine_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Medicine);
            Assert.Same(this.AbilityScores.Wisdom, skillsSection.Medicine.AbilityScore);
        }


        [Fact]
        public void Perception_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Perception);
            Assert.Same(this.AbilityScores.Wisdom, skillsSection.Perception.AbilityScore);
        }


        [Fact]
        public void Survival_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Survival);
            Assert.Same(this.AbilityScores.Wisdom, skillsSection.Survival.AbilityScore);
        }
        #endregion

        #region Charisma
        [Fact]
        public void Deception_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Deception);
            Assert.Same(this.AbilityScores.Charisma, skillsSection.Deception.AbilityScore);
        }


        [Fact]
        public void Intimidation_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Intimidation);
            Assert.Same(this.AbilityScores.Charisma, skillsSection.Intimidation.AbilityScore);
        }


        [Fact]
        public void Performance_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Performance);
            Assert.Same(this.AbilityScores.Charisma, skillsSection.Performance.AbilityScore);
        }


        [Fact]
        public void Persuasion_DefaultConfig()
        {
            // Arrange
            var skillsSection = new SkillsSection(AbilityScores, ProficiencyBonus);

            // Assert
            Assert.IsType<Skill>(skillsSection.Persuasion);
            Assert.Same(this.AbilityScores.Charisma, skillsSection.Persuasion.AbilityScore);
        }
        #endregion
    }
}
