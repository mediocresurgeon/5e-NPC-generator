using System;


namespace DnD5e.Creatures.Items
{
    /// <summary>
    /// An item, such as an inkpen or a suit of enchanted armor.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// This item's name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The name of the book which published this item.
        /// </summary>
        string SourceBook { get; }

        /// <summary>
        /// The page number on which this item was published.
        /// May be inaccurate, since page numbers may shift during different printings.
        /// </summary>
        ushort PageNumber { get; }

        /// <summary>
        /// Not always available.
        /// A remote resource which describes this item in detail.
        /// </summary>
        Uri Url { get; }

        /// <summary>
        /// The cost-to-purchase of this item.
        /// Not all items have a market price associated with them.
        /// </summary>
        decimal? MarketValue { get; }

        /// <summary>
        /// The weight of this item (in pounds).
        /// </summary>
        float Weight { get; }
    }
}