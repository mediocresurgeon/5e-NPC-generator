using System;
using DnD5e.Creatures.Items.MundaneItems;
using DnD5e.Creatures.Spells;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.MundaneItems
{
    public class SpellbookTest
    {
        #region Constructor
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var spellbook = new Spellbook();

            // Act

            // Assert
            Assert.Equal("Spellbook", spellbook.Name);
            Assert.Equal(3, spellbook.Weight);
        }
        #endregion

        #region AddSpell/GetSpell
        [Fact]
        public void AddSpell_NullArg_Throws()
        {
            // Arrange
            ISpell spell = null;
            var spellbook = new Spellbook();

            // Act
            Action addSpell = () => spellbook.AddSpell(spell);

            // Assert
            Assert.Throws<ArgumentNullException>(addSpell);
        }


        [Fact]
        public void AddSpell_Cantrip_Throws()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.SetupGet(s => s.Level)
                     .Returns(0);
            var spell = mockSpell.Object;

            var spellbook = new Spellbook();

            // Act
            Action addSpell = () => spellbook.AddSpell(spell);

            // Assert
            Assert.Throws<ArgumentException>(addSpell);
        }


        [Fact]
        public void AddSpell_RoundTrip()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Level)
                     .Returns(1);
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("fooBarBaz");

            var spellbook = new Spellbook();

            // Act
            spellbook.AddSpell(mockSpell1.Object);
            var result = spellbook.GetSpells();

            // Assert
            Assert.Contains(mockSpell1.Object, result);
        }


        [Fact]
        public void AddSpell_Redundant_Ignored()
        {
            // Arrange
            const string SPELL_NAME = "fooBarBaz";

            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Level)
                     .Returns(1);
            mockSpell1.SetupGet(s => s.Name)
                      .Returns(SPELL_NAME);

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Level)
                     .Returns(1);
            mockSpell2.SetupGet(s => s.Name)
                      .Returns(SPELL_NAME);

            var spellbook = new Spellbook();

            // Act
            spellbook.AddSpell(mockSpell1.Object);
            spellbook.AddSpell(mockSpell2.Object);
            var result = spellbook.GetSpells();

            // Assert
            Assert.Contains(mockSpell1.Object, result);
            Assert.DoesNotContain(mockSpell2.Object, result);
        }


        [Fact]
        public void GetSpell_FiltersByLevel_1()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Level)
                     .Returns(1);
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell1");

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Level)
                     .Returns(2);
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell2");

            var spellbook = new Spellbook();

            // Act
            spellbook.AddSpell(mockSpell1.Object);
            spellbook.AddSpell(mockSpell2.Object);
            var result = spellbook.GetSpells(1);

            // Assert
            Assert.Contains(mockSpell1.Object, result);
            Assert.DoesNotContain(mockSpell2.Object, result);
        }


        [Fact]
        public void GetSpell_FiltersByLevel_2()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Level)
                     .Returns(1);
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell1");

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Level)
                     .Returns(2);
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell2");

            var spellbook = new Spellbook();

            // Act
            spellbook.AddSpell(mockSpell1.Object);
            spellbook.AddSpell(mockSpell2.Object);
            var result = spellbook.GetSpells(2);

            // Assert
            Assert.Contains(mockSpell2.Object, result);
            Assert.DoesNotContain(mockSpell1.Object, result);
        }
        #endregion

        #region MarketValue
        [Fact]
        public void MarketValue_Default()
        {
            // Arrange
            var spellbook = new Spellbook();

            // Act
            var result = spellbook.MarketValue.Value;

            // Assert
            Assert.Equal(50, result);
        }


        [Theory]
        [InlineData(1,  60)]
        [InlineData(2,  70)]
        [InlineData(3,  80)]
        [InlineData(4,  90)]
        [InlineData(5, 100)]
        [InlineData(6, 110)]
        [InlineData(7, 120)]
        [InlineData(8, 130)]
        [InlineData(9, 140)]
        public void MarketValue_SingleSpell(byte spellLevel, decimal expectedValue)
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.SetupGet(s => s.Level)
                     .Returns(spellLevel);

            var spellbook = new Spellbook();
            spellbook.AddSpell(mockSpell.Object);

            // Act
            var result = spellbook.MarketValue.Value;

            // Assert
            Assert.Equal(expectedValue, result);
        }


        [Theory]
        [InlineData(1, 1,  70)]
        [InlineData(1, 2,  80)]
        [InlineData(2, 1,  80)]
        [InlineData(2, 2,  90)]
        public void MarketValue_TwoSpells(byte spellLevel1, byte spellLevel2, decimal expectedValue)
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Level)
                     .Returns(spellLevel1);
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("Spell1");

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Level)
                      .Returns(spellLevel2);
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("Spell2");

            var spellbook = new Spellbook();
            spellbook.AddSpell(mockSpell1.Object);
            spellbook.AddSpell(mockSpell2.Object);

            // Act
            var result = spellbook.MarketValue.Value;

            // Assert
            Assert.Equal(expectedValue, result);
        }
        #endregion
    }
}