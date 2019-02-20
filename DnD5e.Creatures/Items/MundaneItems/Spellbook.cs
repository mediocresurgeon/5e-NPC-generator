using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.Spells;


namespace DnD5e.Creatures.Items.MundaneItems
{
    /// <summary>
    /// A typical spellbook, such as one used by wizards.
    /// </summary>
    public sealed class Spellbook : ISpellbook
    {
        #region Properties
        private List<ISpell> Spells { get; } = new List<ISpell>();

        /// <summary>
        /// This item's name.
        /// </summary>
        public string Name => "Spellbook";

        /// <summary>
        /// The name of the book which published this item.
        /// </summary>
        public string SourceBook => Book.PlayersHandbook;

        /// <summary>
        /// The page number on which this item was published.
        /// May be inaccurate, since page numbers may shift during different printings.
        /// </summary>
        public ushort PageNumber => 153;

        /// <summary>
        /// Not always available.
        /// A remote resource which describes this item in detail.
        /// </summary>
        public Uri Url => new Uri("https://roll20.net/compendium/dnd5e/Spellbook#content");

        /// <summary>
        /// The weight of this item (in pounds).
        /// </summary>
        public float Weight => 3;

        /// <summary>
        /// Returns the market value of this item (in gold pieces).
        /// </summary>
        /* 
         * I assume that the market value of a spellbook is
         * equal to the cost of the book itself (50gp)
         * plus the amount it takes someone to
         * __create a copy of their own spellbook__
         * (10gp per spell level per spell).
         * 
         * This is different than the cost it would take someone to
         * __copy a spell into their own spellbook__
         * (50gp per spell level per spell.)
         * An adventurer who finds a spellbook as loot still has to pay
         * this cost in order to be able to use the spells contained within!            
         * 
         * Reference: PHB pg 114
         */
        public decimal? MarketValue => 50 + this.Spells.Sum(s => s.Level * 10);
        #endregion

        #region Methods
        /// <summary>
        /// Adds a spell into this Spellbook.
        /// </summary>
        /// <param name="spell">The non-cantrip spell to add.</param>
        /// <exception cref="System.ArgumentException" />
        /// <exception cref="System.ArgumentNullException" />
        public void AddSpell(ISpell spell)
        {
            // Do not allow null arguments
            if (null == spell)
                throw new ArgumentNullException(nameof(spell), "Argument may not be null.");
            // Cantrips may not be added
            if (0 == spell.Level)
                throw new ArgumentException($"{ spell.Name } may not be added to a Spellbook because it is a cantrip.", nameof(spell));
            // Ignore duplicate adds
            if (this.Spells.Select(s => s.Name)
                           .Contains(spell.Name))
                return;
            this.Spells.Add(spell);
        }


        /// <summary>
        /// Returns all spells which are recorded in this Spellbook.
        /// </summary>
        public ISpell[] GetSpells()
        {
            return this.Spells.ToArray();
        }


        /// <summary>
        /// Returns all spells which are recorded in this Spellbook which match the specified spell level.
        /// </summary>
        /// <param name="level">The spell level.</param>
        public ISpell[] GetSpells(byte level)
        {
            return this.Spells.Where(s => level == s.Level)
                              .ToArray();
        }
        #endregion
    }
}