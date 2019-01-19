using System;


namespace DnD5e.Creatures.Items.WonderousItems.Core
{
    /// <summary>
    /// A bag which stores items in an extradimensional space.
    /// </summary>
    public sealed class BagOfHolding : IWonderousItem
    {
        /// <summary>
        /// Bag of Holding is uncommon.
        /// </summary>
        public Rarity Rarity => Rarity.Uncommon;

        /// <summary>
        /// Bag of Holding does not require attunement.
        /// </summary>
        public bool RequiresAtunement => false;

        /// <summary>
        /// The name of this wonderous item.
        /// </summary>
        public string Name => "Bag of Holding";

        /// <summary>
        /// Bag of Holding was first printed in the Dungeon Master's Guide.
        /// </summary>
        public string SourceBook => "Dungeon Master's Guide";

        /// <summary>
        /// Bag of Holding can be found on page 150 in the DMG.
        /// </summary>
        public ushort PageNumber => 153;

        /// <summary>
        /// A URL which summarizes this item.
        /// </summary>
        public Uri Url => new Uri("http://5e.d20srd.org/srd/magicItems/magicItemsAToZ.htm#bagOfHolding");

        /// <summary>
        /// Magic items do not have a market value.
        /// </summary>
        public decimal? MarketValue => null;

        /// <summary>
        /// Bag of Holding weighs 15 pounds (regardless of its contents).
        /// </summary>
        public float Weight => 15;
    }
}