using System;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.AbilityChecks
{
    /// <summary>
    /// A character's innate talent and training in an effort to overcome a challenge.
    /// </summary>
    public interface IAbilityCheck
    {
        /// <summary>
        /// The ability score associated with this ability check.
        /// </summary>
        IAbilityScore AbilityScore { get; }

        /// <summary>
        /// Adds a modifier to this ability check.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        void AddModifier(Func<sbyte> modifier);

        /// <summary>
        /// Returns the total modifier for this ability check.
        /// </summary>
        /// <returns>The total.</returns>
        sbyte GetTotal();
    }
}