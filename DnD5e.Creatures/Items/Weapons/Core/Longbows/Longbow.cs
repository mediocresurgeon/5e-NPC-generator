using System;
using DnD5e.Creatures.Attacks;
using DnD5e.Creatures.Dice;


namespace DnD5e.Creatures.Items.Weapons.Core.Longbows
{
    /// <summary>
    /// A large bow.
    /// </summary>
    public class Longbow : ILongbow
    {
        /// <summary>
        /// The name of this weapon.
        /// </summary>
        public virtual string Name => "Longbow";

        /// <summary>
        /// The sourcebook which published the stats for this weapon.
        /// </summary>
        public virtual string SourceBook => Book.PlayersHandbook;

        /// <summary>
        /// The number of the page on which the stats for this weapon can be found.
        /// </summary>
        public virtual ushort PageNumber => 149;

        /// <summary>
        /// A URL (if available) which provides a reference for this weapon.
        /// </summary>
        public virtual Uri Url => new Uri("https://roll20.net/compendium/dnd5e/Items:Longbow#content");

        /// <summary>
        /// The market value of this weapon (in gold pieces).
        /// </summary>
        public virtual decimal? MarketValue => 50;

        /// <summary>
        /// The weight of this weapon (in pounds).
        /// </summary>
        public virtual float Weight => 2;

        /// <summary>
        /// Returns the type of damage this weapon deals.
        /// </summary>
        public virtual WeaponDamageType DamageType => WeaponDamageType.Piercing;

        /// <summary>
        /// Returns this weapon's default damage dice.
        /// </summary>
        public virtual IDiceGroup DamageDice { get; } = new DiceGroup(1, 8);

        /// <summary>
        /// Returns this weapon's alternate damage dice.
        /// May be null.
        /// </summary>
        public virtual IDiceGroup AlternateDamageDice => null;

        /// <summary>
        /// Returns this weapon's first range increment (in squares).
        /// </summary>
        public virtual byte? RangeIncrement1 => 30;

        /// <summary>
        /// Returns this weapon's second range increment (in squares).
        /// </summary>
        public virtual byte? RangeIncrement2 => 120;

        /// <summary>
        /// Returns this weapon's properties.
        /// </summary>
        public virtual WeaponProperty[] GetProperties()
        {
            return new WeaponProperty[] {
                WeaponProperty.Heavy,
                WeaponProperty.Range,
                WeaponProperty.TwoHanded,
            };
        }
    }
}