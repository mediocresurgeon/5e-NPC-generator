namespace DnD5e.Creatures.Spellcasting.Spells
{
    /// <summary>
    /// A physical requirement which must be met in order to cast a spell.
    /// </summary>
    public enum SpellComponent
    {
        /// <summary>
        /// Indicates that a spell requires a particular object in order to be cast.
        /// </summary>
        Material,

        /// <summary>
        /// Indicates that a spell requires forceful gesticulation
        /// or an intricate set of gestures in order to be cast.
        /// </summary>
        Somatic,

        /// <summary>
        /// Indicates that a spell requires the chanting
        /// of mystical words in order to be cast.
        /// </summary>
        Verbal,
    }
}