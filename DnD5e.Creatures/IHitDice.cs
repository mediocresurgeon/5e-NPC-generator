using System;
using DnD5e.Creatures.Dice;


namespace DnD5e.Creatures
{
    /// <summary>
    /// A creature's hit dice.
    /// </summary>
    public interface IHitDice
    {
        /// <summary>
        /// Adds hit dice.
        /// </summary>
        void AddHitDice(IDiceGroup hitDice);

        /// <summary>
        /// Adds bonus hit points.
        /// </summary>
        void AddBonusHitPoints(Func<sbyte> hitPoints);

        /// <summary>
        /// Returns the number of hit dice.
        /// </summary>
        byte HitDiceCount { get; }

        /// <summary>
        /// The minimum hit points.
        /// </summary>
        ushort Min { get; }

        /// <summary>
        /// The maximum hit points.
        /// </summary>
        ushort Max { get; }

        /// <summary>
        /// The average hit points.
        /// </summary>
        ushort Avg { get; }
    }
}