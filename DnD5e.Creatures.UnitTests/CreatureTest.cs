using DnD5e.Creatures.AbilityChecks;
using DnD5e.Creatures.AbilityChecks.Skills;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Dice;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.SavingThrows;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests
{
    public class CreatureTest
    {
        #region Constructor tests
        [Fact]
        public void Constructor_AbilityScores_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<AbilityScoresSection>(character.AbilityScores);
        }


        [Fact]
        public void Constructor_ArmorClass_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<ArmorClass>(character.ArmorClass);
        }


        [Fact]
        public void Constructor_HitPoints_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<HitDice>(character.HitPoints);
        }


        [Fact]
        public void Constructor_Initiative_DefaultConfiguration()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<AbilityCheck>(character.Initiative);
            Assert.Same(character.AbilityScores.Dexterity, character.Initiative.AbilityScore);
        }


        [Fact]
        public void Constructor_GetProficiencyBonus_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.NotNull(character.GetProficiencyBonus);
        }


        [Fact]
        public void Constructor_SavingThrows_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<SavingThrowsSection>(character.SavingThrows);
        }


        [Fact]
        public void Constructor_Skills_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<SkillsSection>(character.Skills);
        }


        [Fact]
        public void Constructor_Equipment_IsNotNull()
        {
            // Arrange
            var character = new Creature();

            // Act

            // Assert
            Assert.IsType<EquipmentSection>(character.Equipment);
        }
        #endregion

        #region Proficiency bonus
        [Theory]
        [InlineData( 0, 2)]
        [InlineData( 1, 2)]
        [InlineData( 4, 2)]
        [InlineData( 5, 3)]
        [InlineData( 6, 3)]
        [InlineData( 8, 3)]
        [InlineData( 9, 4)]
        [InlineData(10, 4)]
        [InlineData(12, 4)]
        [InlineData(13, 5)]
        [InlineData(14, 5)]
        [InlineData(16, 5)]
        [InlineData(17, 6)]
        [InlineData(18, 6)]
        [InlineData(20, 6)]
        public void GetProficiencyBonusFromLevel(byte level, byte expected)
        {
            // Arrange

            // Act
            var result = Creature.GetProficiencyBonusFromLevel(level);

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData( 0, 2)]
        [InlineData( 1, 2)]
        [InlineData( 4, 2)]
        [InlineData( 5, 3)]
        [InlineData( 6, 3)]
        [InlineData( 8, 3)]
        [InlineData( 9, 4)]
        [InlineData(10, 4)]
        [InlineData(12, 4)]
        [InlineData(13, 5)]
        [InlineData(14, 5)]
        [InlineData(16, 5)]
        [InlineData(17, 6)]
        [InlineData(18, 6)]
        [InlineData(20, 6)]
        public void GetProficiencyBonus(byte level, byte expected)
        {
            // Arrange
            var character = new Creature();

            var hd = new Mock<IDiceGroup>();
            hd.Setup(d => d.Quantity)
              .Returns(level);
            hd.Setup(d => d.Quality)
              .Returns(8);

            character.HitPoints.AddHitDice(hd.Object);

            // Act
            var result = character.GetProficiencyBonus();

            // Assert
            Assert.Equal(expected, result);
        }
        #endregion
    }
}