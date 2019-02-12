using System;


namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// Calculates the attack bonus associated with a weapon.
    /// </summary>
    public interface IDamageBonusCalculator
    {
        /// <summary>
        /// The total damage bonus.
        /// </summary>
        sbyte Total { get; set; }

        /// <summary>
        /// Adds a modifier to the damage.
        /// </summary>
        void AddModifier(Func<sbyte> modifier);
    }
}