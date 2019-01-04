namespace DnD5e.Creatures.Items.Armors
{
    /// <summary>
    /// Defensive coverings which protect one's body during battle.
    /// </summary>
    public interface IArmor : IItem, IApplyable
    {
        /// <summary>
        /// The base armor class to bestow upon the creature wearing this armor.
        /// </summary>
        byte BaseArmorValue { get; }
    }
}