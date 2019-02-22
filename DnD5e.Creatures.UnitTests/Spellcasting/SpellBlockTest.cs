using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Spellcasting
{
    public class SpellBlockTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullProficiencyBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = null;
            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();

            // Act
            Action constructor = () => new SpellBlock(proficiencyBonus, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullSpellcastingStatBonus_Throws()
        {
            // Arrange
            Func<byte> proficiencyBonus = () => 2;
            IAbilityScore spellcastingStat = null;

            // Act
            Action constructor = () => new SpellBlock(proficiencyBonus, spellcastingStat);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            Func<byte> proficiencyBonus = () => 2;
            IAbilityScore spellcastingStat = Mock.Of<IAbilityScore>();
            ISpellBlock spellblock = new SpellBlock(proficiencyBonus, spellcastingStat);

            // Act

            // Assert
            Assert.Same(spellcastingStat, spellblock.KeyAbilityScore);
            Assert.IsType<DifficultyClassCalculator>(spellblock.DifficultyClass);
            Assert.IsType<SpellAttackBonusCalculator>(spellblock.AttackBonus);
        }
        #endregion
    }
}
