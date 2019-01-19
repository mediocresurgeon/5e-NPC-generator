using System;
using System.Collections.Generic;
using DnD5e.Creatures.Items.Armors;
using DnD5e.Creatures.Items.WonderousItems;

namespace DnD5e.Creatures.Items
{
    internal sealed class EquipmentSection : IEquipmentSection
    {
        #region Backing variables
        private IArmor _armor;
        #endregion

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

        #region Properties
        /// <summary>
        /// The owner of this equipment.
        /// </summary>
        private ICreature Owner { get; }

        /// <summary>
        /// This creature's wonderous items.
        /// </summary>
        private List<IWonderousItem> WonderousItems { get; } = new List<IWonderousItem>();

        /// <summary>
        /// Returns the equipped armor.
        /// </summary>
        /// <value>The armor.</value>
        public IArmor Armor => _armor;
        #endregion

        #region Methods
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
            if (null != _armor )
                throw new InvalidOperationException($"You may not equip { armor.Name }; { this.Armor.Name } is already equipped.");

            // Happy path
            _armor = armor;
            this.Armor.ApplyTo(this.Owner);
        }

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