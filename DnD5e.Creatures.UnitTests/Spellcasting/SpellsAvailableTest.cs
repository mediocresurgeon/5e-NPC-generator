using System;
using System.Linq;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting;
using DnD5e.Creatures.Spellcasting.Spells;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Spellcasting
{
    public class SpellsAvailableTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = null;

            // Act
            Action constructor = () => new SpellsAvailable(proficiencyBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region AddSpell/GetSpellsAvailable
        [Fact]
        public void AddSpell_NullSpell_Throws()
        {
            // Arrange
            ISpell spell = null; 
            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            Action addSpell = () => spellsAvailable.AddSpell(spell, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(addSpell);
        }


        [Fact]
        public void AddSpell_NullSpellcastingStat_Throws()
        {
            // Arrange
            ISpell spell = Mock.Of<ISpell>();
            IAbilityScore spellcastingStat = null;

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            Action addSpell = () => spellsAvailable.AddSpell(spell, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(addSpell);
        }


        [Fact]
        public void AddSpell_AddSingleSpell_HappyPath()
        {
            // Arrange
            var mockSpell = new Mock<ISpell>();
            mockSpell.SetupGet(s => s.Name)
                     .Returns("spell1");
            ISpell spell = mockSpell.Object;

            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            spellsAvailable.AddSpell(spell, spellcastingStat);
            var result = spellsAvailable.GetSpellsAvailable();

            // Assert
            Assert.Same(spellcastingStat, result.First().Spellblock.KeyAbilityScore);
            Assert.Contains(spell, result.First().Spells);
        }


        [Fact]
        public void AddSpell_AddTwoSpells_SameStat()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell1");
            ISpell spell1 = mockSpell1.Object;

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell2");
            ISpell spell2 = mockSpell2.Object;

            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            spellsAvailable.AddSpell(spell1, spellcastingStat);
            spellsAvailable.AddSpell(spell2, spellcastingStat);
            var result = spellsAvailable.GetSpellsAvailable();

            // Assert
            Assert.Same(spellcastingStat, result.First().Spellblock.KeyAbilityScore);
            Assert.Contains(spell1, result.First().Spells);
            Assert.Contains(spell2, result.First().Spells);
        }


        [Fact]
        public void AddSpell_AddTwoSpells_DifferentStats()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell1");
            ISpell spell1 = mockSpell1.Object;

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell2");
            ISpell spell2 = mockSpell2.Object;

            IAbilityScore spellcastingStat1 = Mock.Of<IAbilityScore>();
            IAbilityScore spellcastingStat2 = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            spellsAvailable.AddSpell(spell1, spellcastingStat1);
            spellsAvailable.AddSpell(spell2, spellcastingStat2);
            var result = spellsAvailable.GetSpellsAvailable();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Contains(spellcastingStat1, result.Select(r => r.Spellblock.KeyAbilityScore));
            Assert.Contains(spellcastingStat2, result.Select(r => r.Spellblock.KeyAbilityScore));
            Assert.Contains(spell1, result.First(r => spellcastingStat1 == r.Spellblock.KeyAbilityScore).Spells);
            Assert.Contains(spell2, result.First(r => spellcastingStat2 == r.Spellblock.KeyAbilityScore).Spells);
        }


        [Fact]
        public void AddSpell_RedundantSpellSameStat_Ignored()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell");
            ISpell spell1 = mockSpell1.Object;

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell");
            ISpell spell2 = mockSpell2.Object;

            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            spellsAvailable.AddSpell(spell1, spellcastingStat);
            spellsAvailable.AddSpell(spell2, spellcastingStat);
            var result = spellsAvailable.GetSpellsAvailable();

            // Assert
            Assert.Single(result);
            Assert.Contains(spellcastingStat, result.Select(r => r.Spellblock.KeyAbilityScore));
            Assert.Single(result.First(r => spellcastingStat == r.Spellblock.KeyAbilityScore).Spells);
            Assert.Contains(spell1, result.First(r => spellcastingStat == r.Spellblock.KeyAbilityScore).Spells);
        }


        [Fact]
        public void AddSpell_RedundantSpellDifferentStat_HappyPath()
        {
            // Arrange
            var mockSpell1 = new Mock<ISpell>();
            mockSpell1.SetupGet(s => s.Name)
                      .Returns("spell");
            ISpell spell1 = mockSpell1.Object;

            var mockSpell2 = new Mock<ISpell>();
            mockSpell2.SetupGet(s => s.Name)
                      .Returns("spell");
            ISpell spell2 = mockSpell2.Object;

            IAbilityScore spellcastingStat1 = Mock.Of<IAbilityScore>();
            IAbilityScore spellcastingStat2 = Mock.Of<IAbilityScore>();

            var spellsAvailable = new SpellsAvailable(() => 2);

            // Act
            spellsAvailable.AddSpell(spell1, spellcastingStat1);
            spellsAvailable.AddSpell(spell2, spellcastingStat2);
            var result = spellsAvailable.GetSpellsAvailable();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Contains(spellcastingStat1, result.Select(r => r.Spellblock.KeyAbilityScore));
            Assert.Contains(spellcastingStat2, result.Select(r => r.Spellblock.KeyAbilityScore));
            Assert.Contains(spell1, result.First(r => spellcastingStat1 == r.Spellblock.KeyAbilityScore).Spells);
            Assert.Contains(spell2, result.First(r => spellcastingStat2 == r.Spellblock.KeyAbilityScore).Spells);
        }
        #endregion
    }
}