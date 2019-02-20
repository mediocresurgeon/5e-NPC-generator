namespace DnD5e.Creatures.Spells
{
    /// <summary>
    /// The type of saving throw allowed by creatures affected by a spell.
    /// </summary>
    public enum SavingThrowType
    {
        /// <summary>
        /// The target(s) are allowed a charisma saving throw.
        /// </summary>
        Charisma,

        /// <summary>
        /// The target(s) are allowed a constitution saving throw.
        /// </summary>
        Constitution,

        /// <summary>
        /// The target(s) are allowed a dexterity saving throw.
        /// </summary>
        Dexterity,

        /// <summary>
        /// The target(s) are allowed a intelligence saving throw.
        /// </summary>
        Intelligence,

        /// <summary>
        /// The target(s) are allowed a strength saving throw.
        /// </summary>
        Strength,

        /// <summary>
        /// The target(s) are allowed a wisdom saving throw.
        /// </summary>
        Wisdom,
    }
}