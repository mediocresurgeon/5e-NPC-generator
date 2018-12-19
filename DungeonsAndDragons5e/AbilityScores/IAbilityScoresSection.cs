namespace DungeonsAndDragons5e.AbilityScores
{
    /// <summary>
    /// A set of basic attributes which represent a character's raw talent and prowess.
    /// </summary>
    public interface IAbilityScoresSection
    {
        /// <summary>
        /// Muscle and physical power.
        /// </summary>
        IAbilityScore Strength { get; }


        /// <summary>
        /// Agility, reflexes, and balance.
        /// </summary>
        IAbilityScore Dexterity { get; }


        /// <summary>
        /// Health and stamina.
        /// </summary>
        IAbilityScore Constitution { get; }


        /// <summary>
        /// Learning and reasoning.
        /// </summary>
        IAbilityScore Intelligence { get; }


        /// <summary>
        /// Willpower, common sense, awareness, and intuition.
        /// </summary>
        IAbilityScore Wisdom { get; }


        /// <summary>
        /// Personality, personal magnetism, ability to lead, and appearance.
        /// </summary>
        IAbilityScore Charisma { get; }
    }
}
