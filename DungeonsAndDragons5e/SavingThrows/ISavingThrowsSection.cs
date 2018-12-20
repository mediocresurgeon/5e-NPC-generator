namespace DungeonsAndDragons5e.SavingThrows
{
    /// <summary>
    /// A set of statistics which govern how well a character can resist harmful effects.
    /// </summary>
    public interface ISavingThrowsSection
    {
        /// <summary>
        /// A measurement of a character's ability to resist adversity through strength.
        /// </summary>
        ISavingThrow Strength { get; }

        /// <summary>
        /// A measurement of a character's ability to resist adversity through dexterity.
        /// </summary>
        ISavingThrow Dexterity { get; }

        /// <summary>
        /// A measurement of a character's ability to resist adversity through constitution.
        /// </summary>
        ISavingThrow Constitution { get; }

        /// <summary>
        /// A measurement of a character's ability to resist adversity through intelligence.
        /// </summary>
        ISavingThrow Intelligence { get; }

        /// <summary>
        /// A measurement of a character's ability to resist adversity through wisdom.
        /// </summary>
        ISavingThrow Wisdom { get; }

        /// <summary>
        /// A measurement of a character's ability to resist adversity through charisma.
        /// </summary>
        ISavingThrow Charisma { get; }
    }
}