using DnD5e.Creatures.AbilityScores;
using Xunit;


namespace DnD5e.Creatures.UnitTests.AbilityScores
{
    public class AbilityScoreTest
    {
        #region Constructor
        [Fact]
        public void Constructor_DefaultScore_10()
        {
            // Arrange
            var score = new AbilityScore();

            // Act

            // Assert
            Assert.Equal(10, score.Score);
        }
        #endregion


        #region Score
        [Theory]
        [InlineData(0)]
        [InlineData(11)]
        [InlineData(20)]
        public void Score_Reassignment(byte value)
        {
            // Arrange
            var score = new AbilityScore();

            // Act
            score.Score = value;

            // Assert
            Assert.Equal(value, score.Score);
        }
        #endregion


        #region Modifier
        [Fact]
        public void Modifier_Zero_Neg5()
        {
            // Arrange
            var score = new AbilityScore { Score = 0 };

            // Act

            // Assert
            Assert.Equal(-5, score.Modifer);
        }

        [Fact]
        public void Modifier_One_Neg4()
        {
            // Arrange
            var score = new AbilityScore { Score = 1 };

            // Act

            // Assert
            Assert.Equal(-5, score.Modifer);
        }


        [Fact]
        public void Modifier_Nine_Neg1()
        {
            // Arrange
            var score = new AbilityScore { Score = 9 };

            // Act

            // Assert
            Assert.Equal(-1, score.Modifer);
        }


        [Fact]
        public void Modifier_Ten_Zero()
        {
            // Arrange
            var score = new AbilityScore { Score = 10 };

            // Act

            // Assert
            Assert.Equal(0, score.Modifer);
        }


        [Fact]
        public void Modifier_Eleven_Zero()
        {
            // Arrange
            var score = new AbilityScore { Score = 11 };

            // Act

            // Assert
            Assert.Equal(0, score.Modifer);
        }


        [Fact]
        public void Modifier_Twenty_Five()
        {
            // Arrange
            var score = new AbilityScore { Score = 20 };

            // Act

            // Assert
            Assert.Equal(5, score.Modifer);
        }
        #endregion
    }
}
