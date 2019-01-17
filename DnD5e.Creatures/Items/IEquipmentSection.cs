using DnD5e.Creatures.Items.Armors;


namespace DnD5e.Creatures.Items
{
    /// <summary>
    /// A creature's equipment.
    /// </summary>
    public interface IEquipmentSection
    {
        /// <summary>
        /// Returns this creature's armor.
        /// May be null.
        /// </summary>
        IArmor Armor { get; }

        /// <summary>
        /// Equips a set of armor to this creature.
        /// Note that only one set of armor can be equipped.
        /// </summary>
        /// <param name="armor">The armor to equip.</param>
        void Equip(IArmor armor);
    }
}