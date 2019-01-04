namespace DnD5e.Creatures.Items
{
    /// <summary>
    /// An enchanted item, such as a +1 Longsword or a Bag of Holding.
    /// </summary>
    public interface IEnchantedItem : IItem
    {
        /// <summary>
        /// The rarity of this item.
        /// </summary>
        Rarity Rarity { get; }

        /// <summary>
        /// Indicates whether or not this item requires attunement in order to function at full capacity.
        /// </summary>
        bool RequiresAtunement { get; }
    }
}