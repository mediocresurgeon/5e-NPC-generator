using System;


namespace DnD5e.Creatures.Items.Armors.Core.RingMails
{
    /// <summary>
    /// Leather armor with heavy rings sewn into it.
    /// </summary>
    public class RingMail : HeavyArmor, IRingMail
    {
        #region Properties
        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        public override byte BaseArmorValue => 14;

        /// <summary>
        /// The name of this armor.
        /// </summary>
        public override string Name => "Ring Mail";

        /// <summary>
        /// The sourcebook which published the stats for this armor.
        /// </summary>
        public override string SourceBook => Book.PlayersHandbook;

        /// <summary>
        /// The number of the page on which the stats for this armor can be found.
        /// </summary>
        public override ushort PageNumber => 145;

        /// <summary>
        /// A URL (if available) which provides a reference for this armor.
        /// </summary>
        public override Uri Url => new Uri("https://www.5esrd.com/equipment/armor/ring-mail/");

        /// <summary>
        /// The market value of this armor (in gold pieces).
        /// </summary>
        public override decimal? MarketValue => 30;

        /// <summary>
        /// The weight of this armor (in pounds).
        /// </summary>
        public override float Weight => 40;
        #endregion
    }
}