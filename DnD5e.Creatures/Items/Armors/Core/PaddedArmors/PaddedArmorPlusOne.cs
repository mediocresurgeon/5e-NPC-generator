﻿using System;


namespace DnD5e.Creatures.Items.Armors.Core.PaddedArmors
{
    /// <summary>
    /// Enchanted quilted layers of cloth and clothing, such as a gambeson.
    /// </summary>
    public sealed class PaddedArmorPlusOne : Armor, IPaddedArmor, IEnchantedItem
    {
        #region Properties
        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        public override byte BaseArmorValue => 12;

        /// <summary>
        /// The name of this armor.
        /// </summary>
        public override string Name => "+1 Padded Armor";

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

        /// <summary>
        /// The weight of this armor (in pounds).
        /// </summary>
        public override float Weight => 8;

        /// <summary>
        /// The rarity of this item.
        /// </summary>
        public Rarity Rarity => Rarity.Rare;

        /// <summary>
        /// Indicates whether or not this item requires attunement in order to function at full capacity.
        /// </summary>
        public bool RequiresAtunement => false;
        #endregion
    }
}