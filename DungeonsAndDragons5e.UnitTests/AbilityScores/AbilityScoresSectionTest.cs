using Xunit;


namespace DungeonsAndDragons5e.UnitTests.AbilityScores
{
    public class AbilityScoresSectionTest
    {
        [Fact]
        public void Constructor_Strength_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Strength);
        }


        [Fact]
        public void Constructor_Dexterity_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Dexterity);
        }


        [Fact]
        public void Constructor_Constitution_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Constitution);
        }


        [Fact]
        public void Constructor_Intelligence_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Intelligence);
        }


        [Fact]
        public void Constructor_Wisdom_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Wisdom);
        }


        [Fact]
        public void Constructor_Charisma_IsNotNull()
        {
            // Arrange
            var scores = new DungeonsAndDragons5e.AbilityScores.AbilityScoresSection();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScore>(scores.Charisma);
        }
    }
}
