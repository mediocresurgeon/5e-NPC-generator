using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting.Spells;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// The spells available to a creature, as Spells Known or Spells Prepared.
    /// </summary>
    internal sealed class SpellsAvailable : ISpellsAvailable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Spellcasting.SpellsAvailable"/> class.
        /// </summary>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SpellsAvailable(Func<byte> proficiencyBonus)
        {
            this.ProficiencyBonus = proficiencyBonus ?? throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
        }
        #endregion

        #region Properties
        private Func<byte> ProficiencyBonus { get; }

        private List<(ISpellBlock Spellblock, List<ISpell> Spells)> Spells { get; } = new List<(ISpellBlock Spellblock, List<ISpell> Spells)>();
        #endregion

        #region Methods
        /// <summary>
        /// Associate a spell with a spellcasting stat so that it can be cast.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="spellcastingStat">The spell's spellcasting stat.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void AddSpell(ISpell spell, IAbilityScore spellcastingStat)
        {
            // Guard against null arguments
            if (null == spell)
                throw new ArgumentNullException(nameof(spell), "Argument may not be null.");
            if (null == spellcastingStat)
                throw new ArgumentNullException(nameof(spellcastingStat), "Argument may not be null.");

            // Make a new SpellBlock if this is the first time the stat has been used
            if (!this.Spells.Any(s => spellcastingStat == s.Spellblock.KeyAbilityScore))
            {
                var spellBlock = new SpellBlock(this.ProficiencyBonus, spellcastingStat);
                this.Spells.Add((spellBlock, new List<ISpell>()));
            }

            var matchedSpells = this.Spells.First(s => spellcastingStat == s.Spellblock.KeyAbilityScore);

            // Ignore duplicates
            if (matchedSpells.Spells.Any(s => spell.Name ==s.Name))
                return;

            // Add the spell
            matchedSpells.Spells.Add(spell);
        }


        /// <summary>
        /// Returns the spells that are available, grouped by their spellcasting stat.
        /// </summary>
        public (ISpellBlock Spellblock, ISpell[] Spells)[] GetSpellsAvailable()
        {
            return this.Spells.Select(s => (s.Spellblock, s.Spells.ToArray()))
                              .ToArray();
        }
        #endregion
    }
}