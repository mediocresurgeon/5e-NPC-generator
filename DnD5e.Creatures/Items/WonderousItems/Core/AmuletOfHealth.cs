using System;


namespace DnD5e.Creatures.Items.WonderousItems.Core
{
    /// <summary>
    /// An amulet which raises one's Constitution score to 19.
    /// </summary>
    public sealed class AmuletOfHealth : IWonderousItem, IApplyable
    {
        /// <summary>
        /// Amulet of Health is rare.
        /// </summary>
        public Rarity Rarity => Rarity.Rare;

        /// <summary>
        /// Amulet of Health requires attunement.
        /// </summary>
        public bool RequiresAtunement => true;

        /// <summary>
        /// The name of this wonderous item.
        /// </summary>
        public string Name => "Amulet of Health";

        /// <summary>
        /// Amulet of Health was first printed in the Dungeon Master's Guide.
        /// </summary>
        public string SourceBook => "Dungeon Master's Guide";

        /// <summary>
        /// Amulet of Health can be found on page 150 in the DMG.
        /// </summary>
        public ushort PageNumber => 150;

        /// <summary>
        /// A URL which summarizes this item.
        /// </summary>
        public Uri Url => new Uri("http://5e.d20srd.org/srd/magicItems/magicItemsAToZ.htm#amuletOfHealth");

        /// <summary>
        /// Magic items do not have a market value.
        /// </summary>
        public decimal? MarketValue => null;

        /// <summary>
        /// Amulet of Health has negligible weight.
        /// </summary>
        public float Weight => 0;

        /// <summary>
        /// Raises one's Constitution score to 19 (unless it is already 19 or higher).
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public void ApplyTo(ICreature creature)
        {
            if (null == creature)
                throw new ArgumentNullException(nameof(creature), "Argument may not be null.");
            if (creature.AbilityScores.Constitution.Score < 19)
            {
                creature.AbilityScores.Constitution.Score = 19;
            }
        }
    }
}