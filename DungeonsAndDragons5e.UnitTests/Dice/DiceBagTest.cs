using System;
using DungeonsAndDragons5e.Dice;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests.Dice
{
    public class DiceBagTest
    {
        [Fact]
        public void Constructor_DefaultConfiguration()
        {
            // Arrange
            var bag = new DiceBag();

            // Act

            // Assert
            Assert.Equal(0, bag.Count);
            Assert.Equal(0, bag.MinRoll);
            Assert.Equal(0, bag.MaxRoll);
            Assert.Empty(bag.ToString());
        }


        [Fact]
        public void Add_Null()
        {
            // Arrange
            var bag = new DiceBag();

            // Act
            bag.Add(null);

            // Assert
            Assert.Equal(0, bag.Count);
            Assert.Equal(0, bag.MinRoll);
            Assert.Equal(0, bag.MaxRoll);
            Assert.Empty(bag.ToString());
        }


        [Theory]
        [InlineData(1, 6,  6, "1d6")]
        [InlineData(2, 8, 16, "2d8")]
        public void Add_SingleDieGroup(byte quantity, byte quality, byte maxRoll, string text)
        {
            // Arrange
            var bag = new DiceBag();

            // Act
            bag.Add(new DiceGroup(quantity, quality));

            // Assert
            Assert.Equal(quantity, bag.Count);
            Assert.Equal(quantity, bag.MinRoll);
            Assert.Equal(maxRoll, bag.MaxRoll);
            Assert.Equal(text, bag.ToString());
        }


        [Theory]
        [InlineData(6, 1, 1, 2, 12, "2d6")]
        [InlineData(6, 2, 1, 3, 18, "3d6")]
        [InlineData(8, 3, 2, 5, 40, "5d8")]
        [InlineData(8, 4, 3, 7, 56, "7d8")]
        public void Add_MultipleDieGroup_SameQuality(byte quality, byte quantity1, byte quantity2, byte count, byte maxRoll, string text)
        {
            // Arrange
            var bag = new DiceBag();

            // Act
            bag.Add(new DiceGroup(quantity1, quality));
            bag.Add(new DiceGroup(quantity2, quality));

            // Assert
            Assert.Equal(count, bag.Count);
            Assert.Equal(count, bag.MinRoll);
            Assert.Equal(maxRoll, bag.MaxRoll);
            Assert.Equal(text, bag.ToString());
        }


        [Theory]
        [InlineData(1, 6, 1, 8, 2, 14, "1d8 + 1d6")]
        [InlineData(2, 6, 1, 8, 3, 20, "2d6 + 1d8")]
        public void Add_MultipleDieGroup_DifferentQuality(byte quantity1,
                                                          byte quality1,
                                                          byte quantity2,
                                                          byte quality2,
                                                          byte count,
                                                          byte maxRoll,
                                                          string text)
        {
            // Arrange
            var bag = new DiceBag();

            // Act
            bag.Add(new DiceGroup(quantity1, quality1));
            bag.Add(new DiceGroup(quantity2, quality2));

            // Assert
            Assert.Equal(count, bag.Count);
            Assert.Equal(count, bag.MinRoll);
            Assert.Equal(maxRoll, bag.MaxRoll);
            Assert.Equal(text, bag.ToString());
        }
    }
}