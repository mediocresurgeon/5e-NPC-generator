namespace DnD5e.Creatures.AbilityScores
{
    /// <summary>
    /// An ability score, such as strength, dexterity, or charisma.
    /// </summary>
    public interface IAbilityScore
    {
        /// <summary>
        /// Gets or sets the magnitude of this ability score.
        /// </summary>
        byte Score { get; set; }


        /// <summary>
        /// Returns the modifier for this ability score.
        /// </summary>
        sbyte Modifer { get; }
    }
}