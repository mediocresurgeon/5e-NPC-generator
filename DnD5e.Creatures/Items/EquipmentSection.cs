using System;
using DnD5e.Creatures.Items.Armors;


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
        /// <value>The equipment owner.</value>
        private ICreature Owner { get; }

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
        #endregion
    }
}