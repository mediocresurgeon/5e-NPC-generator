using System;

namespace DnD5e.Creatures
{
    /// <summary>
    /// A measurement of how difficult it is to hit a character with an attack.
    /// </summary>
    public interface IArmorClass
    {
        /// <summary>
        /// Adds a new base armor bonus.  Only the greatest value will be used.
        /// </summary>
        void AddBase(Func<byte> baseArmorBonus);

        /// <summary>
        /// Adjusts the armor class by the specified amount.
        /// </summary>
        void AddModifier(Func<sbyte> modifier);

        /// <summary>
        /// Restricts the maximum dexterity bonus which can be added to armor class.
        /// </summary>
        void AddMaxDex(Func<byte> maxDex);

        /// <summary>
        /// Calculates the total armor class.
        /// </summary>
        sbyte GetTotal();
    }
}