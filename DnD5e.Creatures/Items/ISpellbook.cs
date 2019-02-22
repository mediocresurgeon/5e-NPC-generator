using DnD5e.Creatures.Spellcasting.Spells;


namespace DnD5e.Creatures.Items
{
    /// <summary>
    /// An item which can be used to record spells.
    /// Typically a book.
    /// </summary>
    public interface ISpellbook : IItem
    {
        /// <summary>
        /// Add a spell to this ISpellbook.
        /// </summary>
        /// <param name="spell">The spell to add to this ISpellbook.</param>
        void AddSpell(ISpell spell);

        /// <summary>
        /// Returns all ISpells recorded in this ISpellbook.
        /// </summary>
        ISpell[] GetSpells();

        /// <summary>
        /// Returns all ISpells recorded in this ISpellbook which match the specified level.
        /// </summary>
        /// <param name="level">The ISpell level to filter by.</param>
        ISpell[] GetSpells(byte level);
    }
}