using Xunit;


namespace DungeonsAndDragons5e.UnitTests
{
    public class CharacterTest
    {
        [Fact]
        public void Constructor_AbilityScores_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<DungeonsAndDragons5e.AbilityScores.AbilityScores>(character.AbilityScores);
        }
    }
}