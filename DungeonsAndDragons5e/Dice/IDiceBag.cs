using System;


namespace DungeonsAndDragons5e.Dice
{
    /// <summary>
    /// A collection of dice, such as a creature's hit dice or a weapon's damage.
    /// </summary>
    public interface IDiceBag
    {
        /// <summary>
        /// Returns the number of dice in this <see cref="T:DungeonsAndDragons5e.Dice.IDiceBag"/>.
        /// </summary>
        byte Count { get; }

        /// <summary>
        /// Returns the minimum possible value for a roll of these dice.
        /// </summary>
        /// <value>The value of the minimum roll.</value>
        byte MinRoll { get; }

        /// <summary>
        /// Returns the maximum possible value for a roll of these dice.
        /// </summary>
        /// <value>The value of the maximum roll.</value>
        byte MaxRoll { get; }

        /// <summary>
        /// Adds dice into this <see cref="T:DungeonsAndDragons5e.Dice.IDiceBag"/>.
        /// </summary>
        /// <param name="dice">The dice to add.</param>
        void Add(IDiceGroup dice);

        /// <summary>
        /// Rolls the dice in this <see cref="T:DungeonsAndDragons5e.Dice.IDiceBag"/>.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        /// <returns>The result of the roll.</returns>
        byte Roll(Random random);
    }
}