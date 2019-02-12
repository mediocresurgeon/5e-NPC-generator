using System;


namespace DnD5e.Creatures.Items.Weapons.Core.Daggers
{
    /// <summary>
    /// A dagger with an enhancement bonus.
    /// </summary>
    public class DaggerEnhanced : Dagger, IEnchantedItem, IApplyable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Items.Weapons.Core.Daggers.DaggerEnhanced"/> class.
        /// </summary>
        /// <param name="enhancementBonus">The enhancement bonus.  Should be no less than 1 and no greater than 3.</param>
        /// <exception cref="System.ArgumentOutOfRangeException" />
        public DaggerEnhanced(byte enhancementBonus)
        {
            if (1 > enhancementBonus || 3 < enhancementBonus)
                throw new ArgumentOutOfRangeException(nameof(enhancementBonus), enhancementBonus, "1 <= Enhancement bonus <= 3");
            this.EnhancementBonus = enhancementBonus;
            this.Rarity = EnhancementEnchantment.GetRarity(this.EnhancementBonus);
        }
        #endregion

        #region Properties
        private byte EnhancementBonus { get; }

        /// <summary>
        /// The rarity of this item.
        /// </summary>
        public Rarity Rarity { get; }

        /// <summary>
        /// The name of this weapon.
        /// </summary>
        public override string Name => $"+{ this.EnhancementBonus } { base.Name }";

        /// <summary>
        /// The sourcebook which published the stats for this armor.
        /// </summary>
        public override string SourceBook => "Dungeon Master's Guide";

        /// <summary>
        /// The number of the page on which the stats for this armor can be found.
        /// </summary>
        public override ushort PageNumber => 213;

        /// <summary>
        /// A URL (if available) which provides a reference for this armor.
        /// </summary>
        public override Uri Url => new Uri($"https://roll20.net/compendium/dnd5e/Dagger%20+{ this.EnhancementBonus }#content");

        /// <summary>
        /// The market value of this weapon (in gold pieces).
        /// </summary>
        public override decimal? MarketValue => null;

        /// <summary>
        /// Gets a value indicating whether this
        /// <see cref="T:DnD5e.Creatures.Items.Weapons.Core.Daggers.DaggerEnhanced"/> requires atunement.
        /// </summary>
        public bool RequiresAtunement => false;
        #endregion

        #region Methods
        /// <summary>
        /// Applies the effects of this dagger to a creature.
        /// </summary>
        /// <param name="creature">The wielder.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void ApplyTo(ICreature creature)
        {
            EnhancementEnchantment.ApplyTo(this, creature, this.EnhancementBonus);
        }
        #endregion
    }
}