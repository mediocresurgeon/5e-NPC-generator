using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// Associates a spell attack bonus and a difficulty class (DC) to spells,
    /// based on an ability score and proficiency bonus.
    /// </summary>
    internal sealed class SpellBlock : ISpellBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Spellcasting.SpellBlock"/> class.
        /// </summary>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <param name="spellcastingStat">The ability score to be used in calculating attack rolls and DCs.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SpellBlock(Func<byte> proficiencyBonus, IAbilityScore spellcastingStat)
        {
            this.KeyAbilityScore = spellcastingStat ?? throw new ArgumentNullException(nameof(spellcastingStat), "Argument may not be null.");
            this.AttackBonus = new SpellAttackBonusCalculator(proficiencyBonus, this.KeyAbilityScore);
            this.DifficultyClass = new DifficultyClassCalculator(proficiencyBonus, this.KeyAbilityScore);
        }

        /// <summary>
        /// The ability score associated with spellcasting.
        /// </summary>
        public IAbilityScore KeyAbilityScore { get; }

        /// <summary>
        /// The attack bonus used when casting spells.
        /// </summary>
        public IAttackBonusCalculator AttackBonus { get; }

        /// <summary>
        /// The difficult class of saving throws for spells.
        /// </summary>
        public IDifficultyClassCalculator DifficultyClass { get; }
    }
}