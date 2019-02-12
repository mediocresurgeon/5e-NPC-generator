using System;

namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// Calculates the attack bonus associated with a weapon.
    /// </summary>
    public interface IAttackBonusCalculator
    {
        /// <summary>
        /// The total attack bonus.
        /// </summary>
        sbyte Total { get; set; }

        /// <summary>
        /// Adds a modifier to the attack roll.
        /// </summary>
        void AddModifier(Func<sbyte> modifier);
    }
}