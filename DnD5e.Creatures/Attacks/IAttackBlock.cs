using DnD5e.Creatures.AbilityScores;

namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// Tracks how well a creature is able to wield a weapon.
    /// </summary>
    public interface IAttackBlock
    {
        /// <summary>
        /// The weapon which is being wielded.
        /// </summary>
        IWeapon Weapon { get; }

        /// <summary>
        /// The bonus at which an attack roll can be made with the weapon.
        /// </summary>
        IAttackBonusCalculator AttackBonus { get; }

        /// <summary>
        /// The bonuses to damage which apply to the weapon.
        /// </summary>
        IDamageBonusCalculator DamageBonus { get; }

        /// <summary>
        /// Allows a nonstandard ability score to be used for attack and damage rolls.
        /// These ability scores will only be used if it is advantageous to do so.
        /// </summary>
        void AddCandidateAbilityScore(IAbilityScore abilityScore);

        /// <summary>
        /// Returns the most advantageous ability score which can be used.
        /// </summary>
        IAbilityScore GetKeyAbilityScore();
    }
}