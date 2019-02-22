using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Spellcasting.Spells;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// The spells available to a creature, such as Spells Known or Spells Prepared.
    /// </summary>
    public interface ISpellsAvailable
    {
        /// <summary>
        /// Associate a spell with a spellcasting stat so that it can be cast.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="spellcastingStat">The spell's spellcasting stat.</param>
        void AddSpell(ISpell spell, IAbilityScore spellcastingStat);

        /// <summary>
        /// Returns the spells that are available.
        /// </summary>
        (ISpellBlock Spellblock, ISpell[] Spells)[] GetSpellsAvailable();
    }
}