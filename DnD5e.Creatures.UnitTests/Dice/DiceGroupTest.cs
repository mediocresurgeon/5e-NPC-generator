using System;
using DnD5e.Creatures.Dice;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Dice
{
    public class DiceGroupTest
    {
        #region Constructor
        [Fact]
        public void Constructor_ZeroQuality_Throws()
        {
            // Arrange
            byte quantity = 1;
            byte quality = 0;

            // Act
            Action constructor = () => new DiceGroup(quantity, quality);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(constructor);
        }


        [Theory]
        [InlineData(1, 6)]
        [InlineData(2, 8)]
        public void Constructor_Args_PassThrough(byte quantity, byte quality)
        {
            // Arrange
            var dg = new DiceGroup(quantity, quality);

            // Act

            // Assert
            Assert.Equal(quantity, dg.Quantity);
            Assert.Equal(quality, dg.Quality);
        }
        #endregion

        [Theory]
        [InlineData(1, 1, "1")]
        [InlineData(7, 1, "7")]
        [InlineData(1, 6, "1d6")]
        [InlineData(2, 8, "2d8")]
        public void ToString_YdX(byte quantity, byte quality, string expected)
        {
            // Arrange
            var dg = new DiceGroup(quantity, quality);

            // Act
            var result = dg.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        #region Equality
        [Fact]
        public void EqualityMethod_Object()
        {
            // Arrange
            var obj = new Object();
            var dg = new DiceGroup(1, 6);

            // Act
            var equal = dg.Equals(obj);

            // Assert
            Assert.False(equal);
        }


        [Fact]
        public void EqualityMethod_Null()
        {
            // Arrange
            Object obj = null;
            var dg = new DiceGroup(1, 6);

            // Act
            var equal = dg.Equals(obj);

            // Assert
            Assert.False(equal);
        }


        [Theory]
        [InlineData(1, 6)]
        [InlineData(2, 8)]
        public void EqualityMethod_DifferentObject(byte quantity, byte quality)
        {
            // Arrange
            var dg1 = new DiceGroup(quantity, quality);
            var dg2 = new DiceGroup(quantity, quality);

            // Act
            var equal = dg1.Equals(dg2);

            // Assert
            Assert.True(equal);
        }


        [Fact]
        public void EqualityOperator_DifferentObject()
        {
            // Arrange
            var dg1 = new DiceGroup(1, 6);
            var dg2 = new DiceGroup(1, 6);

            // Act
            var equal = dg1 == dg2;

            // Assert
            Assert.True(equal);
        }


        [Fact]
        public void InequalityOperator_DifferentObjectSameData()
        {
            // Arrange
            var dg1 = new DiceGroup(1, 6);
            var dg2 = new DiceGroup(1, 6);

            // Act
            var equal = dg1 != dg2;

            // Assert
            Assert.False(equal);
        }


        [Theory]
        [InlineData(1, 6, 1, 8)]
        [InlineData(1, 6, 2, 6)]
        public void InequalityOperator_DifferentObjectDifferentData(byte quan1, byte qual1, byte quan2, byte qual2)
        {
            // Arrange
            var dg1 = new DiceGroup(quan1, qual1);
            var dg2 = new DiceGroup(quan2, qual2);

            // Act
            var equal = dg1 != dg2;

            // Assert
            Assert.True(equal);
        }
        #endregion
    }
}