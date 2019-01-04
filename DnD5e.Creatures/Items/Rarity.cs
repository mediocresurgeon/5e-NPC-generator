namespace DnD5e.Creatures.Items
{
    /// <summary>
    /// Indicates the rarity of an item.
    /// </summary>
    public enum Rarity
    {
        /// <summary>
        /// Indicates that an item is abundant.
        /// Appropriate for characters of all levels.
        /// </summary>
        Common,

        /// <summary>
        /// Indicates that encountering such an item is improbable.
        /// Appropriate for characters of all levels.
        /// </summary>
        Uncommon,

        /// <summary>
        /// Indicates that encountering such an item is highly improbable.
        /// Appropriate for characters level 5+.
        /// </summary>
        Rare,

        /// <summary>
        /// Indicates that encountering such an item is exceedingly unlikely.
        /// Appropriate for characters level 11+.
        /// </summary>
        VeryRare,

        /// <summary>
        /// Indicates that encountering such an item is so unusual as to be effectively impossible.
        /// Appropriate for character level 17+.
        /// </summary>
        Legendary,
    }
}