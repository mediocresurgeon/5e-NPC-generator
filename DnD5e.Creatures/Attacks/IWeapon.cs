using DnD5e.Creatures.Dice;

namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// Something used to inflict physical damage upon a creature or object,
    /// such as an unarmed strike, a claw, or a sword.
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        /// Returns the name of this weapon.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the type of damage this weapon deals.
        /// </summary>
        WeaponDamageType DamageType { get; }

        /// <summary>
        /// Returns this weapon's default damage dice.
        /// </summary>
        IDiceGroup DamageDice { get; }

        /// <summary>
        /// Returns this weapon's alternate damage dice.
        /// May be null.
        /// </summary>
        IDiceGroup AlternateDamageDice { get; }

        /// <summary>
        /// Returns this weapon's first range increment (in squares).
        /// </summary>
        byte? RangeIncrement1 { get; }

        /// <summary>
        /// Returns this weapon's second range increment (in squares).
        /// </summary>
        byte? RangeIncrement2 { get; }

        /// <summary>
        /// Returns this weapon's properties.
        /// </summary>
        WeaponProperty[] GetProperties();
    }
}