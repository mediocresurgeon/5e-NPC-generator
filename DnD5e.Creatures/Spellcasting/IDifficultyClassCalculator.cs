using System;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// Calculates the DC of a spell.
    /// </summary>
    public interface IDifficultyClassCalculator
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        sbyte Total { get; set; }

        /// <summary>
        /// Adds a modifier to this DC calculator.
        /// </summary>
        void AddModifier(Func<sbyte> modifier);
    }
}