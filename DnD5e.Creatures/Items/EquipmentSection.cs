using System;
using System.Collections.Generic;
using DnD5e.Creatures.Items.Armors;
using DnD5e.Creatures.Items.Weapons;
using DnD5e.Creatures.Items.WonderousItems;


namespace DnD5e.Creatures.Items
{
    internal sealed class EquipmentSection : IEquipmentSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Items.EquipmentSection"/> class.
        /// </summary>
        /// <param name="owner">The owner of this equipment section.</param>
        /// <exception cref="System.ArgumentNullException" />
        internal EquipmentSection(ICreature owner)
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner), "Argument may not be null.");
        }
        #endregion

        /// <summary>
        /// The owner of this equipment.
        /// </summary>
        private ICreature Owner { get; }


        #region Armor
        /// <summary>
        /// Returns the equipped armor.
        /// </summary>
        public IArmor Armor { get; private set; }


        /// <summary>
        /// Equips a set of armor to this creature.
        /// Note that only one set of armor can be equipped.
        /// </summary>
        /// <param name="armor">The armor to equip.</param>
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.InvalidOperationException" />
        public void Equip(IArmor armor)
        {
            // Arg should not be null
            if (null == armor)
                throw new ArgumentNullException(nameof(armor), "Argument may not be null.");

            // If the armor has already been equipped, ignore the command
            if (this.Armor == armor)
                return;

            // If there is already armor equipped, fail out
            if (null != this.Armor )
                throw new InvalidOperationException($"You may not equip { armor.Name }; { this.Armor.Name } is already equipped.");

            // Happy path
            this.Armor = armor;
            this.Armor.ApplyTo(this.Owner);
        }
        #endregion

        #region Weapons
        /// <summary>
        /// This creature's weapons.
        /// </summary>
        private List<IManufacturedWeapon> Weapons { get; } = new List<IManufacturedWeapon>();


        /// <summary>
        /// Returns this creature's weapons.
        /// </summary>
        /// <returns>The weapons.</returns>
        public IManufacturedWeapon[] GetWeapons()
        {
            return this.Weapons.ToArray();
        }


        /// <summary>
        /// Equips a weapon to this creature.
        /// </summary>
        /// <param name="weapon">The weapon to equip.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void Equip(IManufacturedWeapon weapon)
        {
            // Arg should not be null
            if (null == weapon)
                throw new ArgumentNullException(nameof(weapon), "Argument may not be null.");

            // Redundant adds should be ignored
            if (this.Weapons.Contains(weapon))
                return;

            // Happy path
            this.Weapons.Add(weapon);
            this.Owner.AddAttack(weapon);
            (weapon as IApplyable)?.ApplyTo(this.Owner);
        }
        #endregion

        #region Spellbook
        /// <summary>
        /// Returns the equipped spellbook.
        /// </summary>
        public ISpellbook Spellbook { get; private set; }


        /// <summary>
        /// Equips a spellbook to this creature.
        /// </summary>
        /// <param name="spellbook">The spellbook to equip.</param>
        /// <exception cref="System.ArgumentNullException" />
        /// <exception cref="System.InvalidOperationException" />
        public void Equip(ISpellbook spellbook)
        {
            // Arg should not be null
            if (null == spellbook)
                throw new ArgumentNullException(nameof(spellbook), "Argument may not be null.");

            // If the spellbook has already been equipped, ignore the command
            if (this.Spellbook == spellbook)
                return;

            // If there is already a spellbook equipped, fail out
            if (null != this.Spellbook)
                throw new InvalidOperationException($"You may not equip { spellbook.Name }; { this.Spellbook.Name } is already equipped.");

            // Happy path
            this.Spellbook = spellbook;
            (spellbook as IApplyable)?.ApplyTo(this.Owner);
        }
        #endregion

        #region Wonderous Items
        /// <summary>
        /// This creature's wonderous items.
        /// </summary>
        private List<IWonderousItem> WonderousItems { get; } = new List<IWonderousItem>();


        /// <summary>
        /// Returns this creature's wonderous items.
        /// </summary>
        public IWonderousItem[] GetWonderousItems()
        {
            return this.WonderousItems.ToArray();
        }


        /// <summary>
        /// Equips a wonderous item to this creature.
        /// </summary>
        /// <param name="wonderousItem">The wonderous item to equip.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void Equip(IWonderousItem wonderousItem)
        {
            // Arg should not be null
            if (null == wonderousItem)
                throw new ArgumentNullException(nameof(wonderousItem), "Argument may not be null.");

            // Redundant adds should be ignored
            if (this.WonderousItems.Contains(wonderousItem))
                return;

            // Happy path
            this.WonderousItems.Add(wonderousItem);
            (wonderousItem as IApplyable)?.ApplyTo(this.Owner);
        }
        #endregion
    }
}