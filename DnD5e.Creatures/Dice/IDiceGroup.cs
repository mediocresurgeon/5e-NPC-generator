using System;


namespace DnD5e.Creatures.Dice
{
    /// <summary>
    /// Represents a set of dice, such as 1d4 or 2d6.
    /// </summary>
    public interface IDiceGroup : IEquatable<IDiceGroup>
    {
        /// <summary>
        /// The number of dice in this <see cref="T:DnD5e.Creatures.Dice.IDiceGroup"/>.
        /// </summary>
        byte Quantity { get; }

        /// <summary>
        /// The number of sides on each of the dice in this <see cref="T:DnD5e.Creatures.Dice.IDiceGroup"/>.
        /// </summary>
        byte Quality { get; }

        /// <summary>
        /// Rolls the dice in this <see cref="T:DnD5e.Creatures.Dice.IDiceGroup"/>.
        /// </summary>
        /// <param name="random">A random number generator.</param>
        /// <returns>The sum of the resultant die faces.</returns>
        byte Roll(Random random);
    }
}