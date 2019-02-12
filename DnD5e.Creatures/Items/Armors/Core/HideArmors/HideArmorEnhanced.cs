using System;


namespace DnD5e.Creatures.Items.Armors.Core.HideArmors
{
    /// <summary>
    /// Hide armor with an enhancement bonus.
    /// </summary>
    public sealed class HideArmorEnhanced : HideArmor, IEnchantedItem
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:DnD5e.Creatures.Items.Armors.Core.HideArmors.HideArmorEnhanced"/> class.
        /// </summary>
        /// <param name="enhancementBonus">The enhancement bonus.  Should be no less than 1 and no greater than 3.</param>
        /// <exception cref="System.ArgumentOutOfRangeException" />
        public HideArmorEnhanced(byte enhancementBonus)
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
        /// Gets a value indicating whether this
        /// <see cref="T:DnD5e.Creatures.Items.Armors.Core.HideArmors.HideArmorEnhanced"/> requires atunement.
        /// </summary>
        public bool RequiresAtunement => false;

        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        public override byte BaseArmorValue => Convert.ToByte(base.BaseArmorValue + this.EnhancementBonus);

        /// <summary>
        /// The name of this armor.
        /// </summary>
        public override string Name => $"+{ this.EnhancementBonus } { base.Name }";

        /// <summary>
        /// The sourcebook which published the stats for this armor.
        /// </summary>
        public override string SourceBook => "Dungeon Master's Guide";

        /// <summary>
        /// The number of the page on which the stats for this armor can be found.
        /// </summary>
        public override ushort PageNumber => 152;

        /// <summary>
        /// A URL (if available) which provides a reference for this armor.
        /// </summary>
        public override Uri Url => new Uri("http://www.5esrd.com/gamemastering/magic-items/magic-armor-and-weapons#TOC-Armor-1-2-or-3");

        /// <summary>
        /// The market value of this armor (in gold pieces).
        /// </summary>
        public override decimal? MarketValue => null;
        #endregion
    }
}