using System;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.SavingThrows
{
    /// <summary>
    /// A statistic which governs how well a character is able to resist harmful effects.
    /// </summary>
    public interface ISavingThrow
    {
        /// <summary>
        /// Indicates whether or not the character is proficient with this saving throw.
        /// </summary>
        bool IsProficient { get; set; }

        /// <summary>
        /// Adds a modifier to this saving throw.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        void AddModifier(Func<sbyte> modifier);

        /// <summary>
        /// Returns the total modifier for this saving throw.
        /// </summary>
        /// <returns>The total.</returns>
        sbyte GetTotal();
    }
}