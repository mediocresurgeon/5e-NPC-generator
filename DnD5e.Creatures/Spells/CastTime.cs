namespace DnD5e.Creatures.Spells
{
    /// <summary>
    /// The amount of time it takes to cast a spell.
    /// </summary>
    public enum CastTime
    {
        /// <summary>
        /// Indicates that it takes 1 action to cast a spell.
        /// </summary>
        Action,

        /// <summary>
        /// Indicates that a spell may be cast as a bonus action.
        /// </summary>
        BonusAction,

        /// <summary>
        /// Indicates that a spell may be cast as a reaction.
        /// </summary>
        Reaction,

        /// <summary>
        /// Indicates that it takes 1 minute to cast a spell.
        /// </summary>
        OneMinute,

        /// <summary>
        /// Indicates that it takes 10 minutes to cast a spell.
        /// </summary>
        TenMinutes,

        /// <summary>
        /// Indicates that it takes 1 hour to cast a spell.
        /// </summary>
        OneHour,

        /// <summary>
        /// Indicates that it takes 8 hours to cast a spell.
        /// </summary>
        EightHours,
    }
}