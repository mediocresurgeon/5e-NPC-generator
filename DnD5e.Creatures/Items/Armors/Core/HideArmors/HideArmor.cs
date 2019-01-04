using System;


namespace DnD5e.Creatures.Items.Armors.Core.HideArmors
{
    /// <summary>
    /// Crude armor consisting of thick furs pelts.
    /// </summary>
    public sealed class HideArmor : MediumArmor, IHideArmor
    {
        #region Properties
        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        public override byte BaseArmorValue => 12;

        /// <summary>
        /// The name of this armor.
        /// </summary>
        public override string Name => "Hide Armor";

        /// <summary>
        /// The sourcebook which published the stats for this armor.
        /// </summary>
        public override string SourceBook => "Player's Handbook";

        /// <summary>
        /// The number of the page on which the stats for this armor can be found.
        /// </summary>
        public override ushort PageNumber => 144;

        /// <summary>
        /// A URL (if available) which provides a reference for this armor.
        /// </summary>
        public override Uri Url => new Uri("https://www.5esrd.com/equipment/armor/hide/");

        /// <summary>
        /// The market value of this armor (in gold pieces).
        /// </summary>
        public override decimal? MarketValue => 10;

        /// <summary>
        /// The weight of this armor (in pounds).
        /// </summary>
        public override float Weight => 12;
        #endregion
    }
}