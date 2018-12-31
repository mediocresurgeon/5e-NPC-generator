using DungeonsAndDragons5e.AbilityChecks;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.SavingThrows;
using Xunit;


namespace DungeonsAndDragons5e.UnitTests
{
    public class CharacterTest
    {
        #region Constructor tests
        [Fact]
        public void Constructor_AbilityScores_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<AbilityScoresSection>(character.AbilityScores);
        }


        [Fact]
        public void Constructor_HitPoints_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<HitDice>(character.HitPoints);
        }


        [Fact]
        public void Constructor_ArmorClass_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<ArmorClass>(character.ArmorClass);
        }


        [Fact]
        public void Constructor_SavingThrows_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<SavingThrowsSection>(character.SavingThrows);
        }


        [Fact]
        public void Constructor_Skills_IsNotNull()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<SkillsSection>(character.Skills);
        }


        [Fact]
        public void Constructor_Initiative_DefaultConfiguration()
        {
            // Arrange
            var character = new Character();

            // Act

            // Assert
            Assert.IsType<AbilityCheck>(character.Initiative);
            Assert.Same(character.AbilityScores.Dexterity, character.Initiative.AbilityScore);
        }
        #endregion
    }
}