using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// Attack bonus and difficult classes for spells.
    /// </summary>
    public interface ISpellBlock
    {
        /// <summary>
        /// The ability score associated with spellcasting.
        /// </summary>
        IAbilityScore KeyAbilityScore { get; }

        /// <summary>
        /// The attack bonus used when casting spells.
        /// </summary>
        IAttackBonusCalculator AttackBonus { get; }

        /// <summary>
        /// The difficult class of saving throws for spells.
        /// </summary>
        IDifficultyClassCalculator DifficultyClass { get; }
    }
}