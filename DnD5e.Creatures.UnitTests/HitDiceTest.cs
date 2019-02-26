using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Dice;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests
{
    public class HitDiceTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullConstitution_Throws()
        {
            // Arrange
            IAbilityScore con = null;

            // Act
            Action constructor = () => new HitDice(con);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region AddBonusHitPoints
        [Fact]
        public void AddBonusHitPoints_NullArgument_Throws()
        {
            // Arrange
            var con = Mock.Of<IAbilityScore>();
            var hd = new HitDice(con);

            // Act
            Action add = () => hd.AddBonusHitPoints(null);

            // Assert
            Assert.Throws<ArgumentNullException>(add);
        }
        #endregion

        #region AddHitDice
        [Fact]
        public void AddHitDice_NullArgument_Throws()
        {
            // Arrange
            var con = Mock.Of<IAbilityScore>();
            var hd = new HitDice(con);

            // Act
            Action add = () => hd.AddHitDice(null);

            // Assert
            Assert.Throws<ArgumentNullException>(add);
        }
        #endregion

        #region HitDiceCount
        [Theory]
        [InlineData( 1,  6,  1)]
        [InlineData(20, 10, 20)]
        public void HitDiceCount_SingleBatch(byte hdCount, byte hdType, byte expected)
        {
            // Arrange
            var con = Mock.Of<IAbilityScore>();

            var dice = new Mock<IDiceGroup>();
            dice.Setup(d => d.Quantity)
                .Returns(hdCount);
            dice.Setup(d => d.Quality)
                .Returns(hdType);

            var hd = new HitDice(con);
            hd.AddHitDice(dice.Object);

            // Act
            var result = hd.HitDiceCount;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region Min
        [Theory]
        [InlineData( 1, 6,  0,  1)]
        [InlineData( 1, 6,  1,  2)]
        [InlineData( 1, 6, -2,  1)]
        [InlineData(20, 8,  0, 20)]
        [InlineData(20, 8,  1, 40)]
        [InlineData(20, 8, -2, 20)]
        public void Min_SingleBatch(byte hdCount, byte hdType, sbyte conMod, byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice = new Mock<IDiceGroup>();
            dice.Setup(d => d.Quantity)
                .Returns(hdCount);
            dice.Setup(d => d.Quality)
                .Returns(hdType);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice.Object);

            // Act
            var result = hd.Min;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData( 1, 8,  1, 6,  0,  2)]
        [InlineData( 1, 8,  1, 6,  1,  4)]
        [InlineData( 1, 8,  1, 6, -2,  2)]
        [InlineData(10, 8, 10, 6,  0, 20)]
        [InlineData(10, 8, 10, 6,  1, 40)]
        [InlineData(10, 8, 10, 6, -2, 20)]
        public void Min_DoubleBatch(byte hdCount1,
                                    byte hdType1,
                                    byte hdCount2,
                                    byte hdType2,
                                    sbyte conMod,
                                    byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice1 = new Mock<IDiceGroup>();
            dice1.Setup(d => d.Quantity)
                .Returns(hdCount1);
            dice1.Setup(d => d.Quality)
                .Returns(hdType1);

            var dice2 = new Mock<IDiceGroup>();
            dice2.Setup(d => d.Quantity)
                .Returns(hdCount2);
            dice2.Setup(d => d.Quality)
                .Returns(hdType2);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice1.Object);
            hd.AddHitDice(dice2.Object);

            // Act
            var result = hd.Min;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region Max
        [Theory]
        [InlineData( 1, 6,  0,   6)]
        [InlineData( 1, 6,  1,   7)]
        [InlineData( 1, 6, -2,   4)]
        [InlineData(20, 8,  0, 160)]
        [InlineData(20, 8,  1, 180)]
        [InlineData(20, 8, -2, 120)]
        public void Max_SingleBatch(byte hdCount, byte hdType, sbyte conMod, byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice = new Mock<IDiceGroup>();
            dice.Setup(d => d.Quantity)
                .Returns(hdCount);
            dice.Setup(d => d.Quality)
                .Returns(hdType);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice.Object);

            // Act
            var result = hd.Max;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData( 1, 8,  1, 6,  0,  14)]
        [InlineData( 1, 8,  1, 6,  1,  16)]
        [InlineData( 1, 8,  1, 6, -2,  10)]
        [InlineData(10, 8, 10, 6,  0, 140)]
        [InlineData(10, 8, 10, 6,  1, 160)]
        [InlineData(10, 8, 10, 6, -2, 100)]
        public void Max_DoubleBatch(byte hdCount1,
                                    byte hdType1,
                                    byte hdCount2,
                                    byte hdType2,
                                    sbyte conMod,
                                    byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice1 = new Mock<IDiceGroup>();
            dice1.Setup(d => d.Quantity)
                .Returns(hdCount1);
            dice1.Setup(d => d.Quality)
                .Returns(hdType1);

            var dice2 = new Mock<IDiceGroup>();
            dice2.Setup(d => d.Quantity)
                .Returns(hdCount2);
            dice2.Setup(d => d.Quality)
                .Returns(hdType2);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice1.Object);
            hd.AddHitDice(dice2.Object);

            // Act
            var result = hd.Max;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region Avg
        [Theory]
        [InlineData(1, 6,  0, 3)]
        [InlineData(2, 6,  0, 7)]
        [InlineData(1, 8,  0, 4)]
        [InlineData(2, 8,  0, 9)]
        [InlineData(1, 6,  1, 4)]
        [InlineData(2, 6,  1, 9)]
        [InlineData(1, 8,  1, 5)]
        [InlineData(2, 8,  1, 11)]
        public void Avg_SingleBatch(byte hdCount, byte hdType, sbyte conMod, byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice = new Mock<IDiceGroup>();
            dice.Setup(d => d.Quantity)
                .Returns(hdCount);
            dice.Setup(d => d.Quality)
                .Returns(hdType);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice.Object);

            // Act
            var result = hd.Avg;

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(1, 8, 1, 6, 0,  8)]
        [InlineData(1, 8, 1, 6, 1, 10)]
        public void Avg_DoubleBatch(byte hdCount1,
                                    byte hdType1,
                                    byte hdCount2,
                                    byte hdType2,
                                    sbyte conMod,
                                    byte expected)
        {
            // Arrange
            var con = new Mock<IAbilityScore>();
            con.Setup(c => c.Modifer)
               .Returns(conMod);

            var dice1 = new Mock<IDiceGroup>();
            dice1.Setup(d => d.Quantity)
                 .Returns(hdCount1);
            dice1.Setup(d => d.Quality)
                 .Returns(hdType1);

            var dice2 = new Mock<IDiceGroup>();
            dice2.Setup(d => d.Quantity)
                 .Returns(hdCount2);
            dice2.Setup(d => d.Quality)
                 .Returns(hdType2);

            var hd = new HitDice(con.Object);
            hd.AddHitDice(dice1.Object);
            hd.AddHitDice(dice2.Object);

            // Act
            var result = hd.Avg;

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion

        #region ToString
        [Theory]
        [InlineData(1,  8,  0,  "1d8")]
        [InlineData(1,  8,  1,  "1d8 + 1")]
        [InlineData(1,  8, -1,  "1d8 - 1")]
        [InlineData(2, 10,  2, "2d10 + 4")]
        [InlineData(2, 10, -1, "2d10 - 2")]
        public void ToString_SingleHitDiceType(byte hdCount, byte hdType, sbyte conMod, string expected)
        {
            // Arrange
            var mockCon = new Mock<IAbilityScore>();
            mockCon.Setup(c => c.Modifer)
                   .Returns(conMod);

            var dice = new Mock<IDiceGroup>();
            dice.Setup(d => d.Quantity)
                .Returns(hdCount);
            dice.Setup(d => d.Quality)
                .Returns(hdType);

            var hd = new HitDice(mockCon.Object);
            hd.AddHitDice(dice.Object);

            // Act
            var result = hd.ToString();

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(1, 8, 1, 6, 0, "1d8 + 1d6")]
        [InlineData(1, 8, 2, 6, 0, "2d6 + 1d8")]
        [InlineData(1, 8, 2, 6, 1, "2d6 + 1d8 + 3")]
        [InlineData(1, 8, 2, 6, -1, "2d6 + 1d8 - 3")]
        public void ToString_MultipleHitDiceType(byte hdCount1,
                                                 byte hdType1,
                                                 byte hdCount2,
                                                 byte hdType2,
                                                 sbyte conMod,
                                                 string expected)
        {
            // Arrange
            var mockCon = new Mock<IAbilityScore>();
            mockCon.Setup(c => c.Modifer)
                   .Returns(conMod);

            var dice1 = new Mock<IDiceGroup>();
            dice1.Setup(d => d.Quantity)
                 .Returns(hdCount1);
            dice1.Setup(d => d.Quality)
                 .Returns(hdType1);

            var dice2 = new Mock<IDiceGroup>();
            dice2.Setup(d => d.Quantity)
                 .Returns(hdCount2);
            dice2.Setup(d => d.Quality)
                 .Returns(hdType2);

            var hd = new HitDice(mockCon.Object);
            hd.AddHitDice(dice1.Object);
            hd.AddHitDice(dice2.Object);

            // Act
            var result = hd.ToString();

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}