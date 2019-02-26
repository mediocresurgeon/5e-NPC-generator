using DnD5e.Creatures.Spellcasting;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Spellcasting
{
    public class SpellSlotsTest
    {
        #region Slots
        [Theory]
        [InlineData( 0, 0)]
        [InlineData( 1, 2)]
        [InlineData( 2, 3)]
        [InlineData( 3, 4)]
        [InlineData(20, 4)]
        public void Level1(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level1;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level1_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level1 = slots;
            var result = spellSlots.Level1;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData( 2, 0)]
        [InlineData( 3, 2)]
        [InlineData( 4, 3)]
        [InlineData(20, 3)]
        public void Level2(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level2;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level2_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level2 = slots;
            var result = spellSlots.Level2;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData( 4, 0)]
        [InlineData( 5, 2)]
        [InlineData( 6, 3)]
        [InlineData(20, 3)]
        public void Level3(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level3;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level3_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level3 = slots;
            var result = spellSlots.Level3;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData( 6, 0)]
        [InlineData( 7, 1)]
        [InlineData( 8, 2)]
        [InlineData( 9, 3)]
        [InlineData(20, 3)]
        public void Level4(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level4;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level4_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level4 = slots;
            var result = spellSlots.Level4;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData( 8, 0)]
        [InlineData( 9, 1)]
        [InlineData(10, 2)]
        [InlineData(17, 2)]
        [InlineData(18, 3)]
        [InlineData(20, 3)]
        public void Level5(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level5;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level5_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level5 = slots;
            var result = spellSlots.Level5;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData(10, 0)]
        [InlineData(11, 1)]
        [InlineData(18, 1)]
        [InlineData(19, 2)]
        [InlineData(20, 2)]
        public void Level6(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level6;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level6_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level6 = slots;
            var result = spellSlots.Level6;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData(12, 0)]
        [InlineData(13, 1)]
        [InlineData(19, 1)]
        [InlineData(20, 2)]
        public void Level7(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level7;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level7_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level7 = slots;
            var result = spellSlots.Level7;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData(14, 0)]
        [InlineData(15, 1)]
        [InlineData(20, 1)]
        public void Level8(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level8;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level8_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level8 = slots;
            var result = spellSlots.Level8;

            // Assert
            Assert.Equal(slots, result);
        }


        [Theory]
        [InlineData( 0, 0)]
        [InlineData(16, 0)]
        [InlineData(17, 1)]
        [InlineData(20, 1)]
        public void Level9(byte casterLevel, byte expected)
        {
            // Arrange
            var spellSlots = new SpellSlots(() => casterLevel);

            // Act
            var result = spellSlots.Level9;

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Level9_Override()
        {
            // Arrange
            byte slots = 20;
            var spellSlots = new SpellSlots(() => 20);

            // Act
            spellSlots.Level9 = slots;
            var result = spellSlots.Level9;

            // Assert
            Assert.Equal(slots, result);
        }
        #endregion
    }
}