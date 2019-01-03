using DnD5e.Creatures.AbilityScores;
using Xunit;


namespace DnD5e.Creatures.UnitTests.AbilityScores
{
    public class AbilityScoresSectionTest
    {
        [Fact]
        public void Constructor_Strength_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Strength);
        }


        [Fact]
        public void Constructor_Dexterity_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Dexterity);
        }


        [Fact]
        public void Constructor_Constitution_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Constitution);
        }


        [Fact]
        public void Constructor_Intelligence_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Intelligence);
        }


        [Fact]
        public void Constructor_Wisdom_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Wisdom);
        }


        [Fact]
        public void Constructor_Charisma_IsNotNull()
        {
            // Arrange
            var scores = new AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<AbilityScore>(scores.Charisma);
        }
    }
}
