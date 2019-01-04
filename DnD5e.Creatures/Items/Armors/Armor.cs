using System;


namespace DnD5e.Creatures.Items.Armors
{
    /// <summary>
    /// A suit or armor, such as leather armor or plate mail.
    /// </summary>
    public abstract class Armor : IArmor
    {
        #region Properties
        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        public abstract byte BaseArmorValue { get; }

        /// <summary>
        /// The name of this armor.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The sourcebook which published the stats for this armor.
        /// </summary>
        public abstract string SourceBook { get; }

        /// <summary>
        /// The number of the page on which the stats for this armor can be found.
        /// </summary>
        public abstract ushort PageNumber { get; }

        /// <summary>
        /// A URL (if available) which provides a reference for this armor.
        /// </summary>
        public abstract Uri Url { get; }

        /// <summary>
        /// The market value of this armor (in gold pieces).
        /// </summary>
        public abstract decimal? MarketValue { get; }

        /// <summary>
        /// The weight of this armor (in pounds).
        /// </summary>
        public abstract float Weight { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Applies the effects of this armor to the creature who is wearing it.
        /// </summary>
        /// <param name="creature">The creature who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException" />
        public virtual void ApplyTo(ICreature creature)
        {
            if (null == creature)
                throw new ArgumentNullException(nameof(creature), "Argument may not be null.");
            creature.ArmorClass.AddBase(() => this.BaseArmorValue);
            // TODO: Put this item in the creature's armor slot
        }
        #endregion
    }
}