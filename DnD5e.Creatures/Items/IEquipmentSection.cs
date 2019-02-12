using DnD5e.Creatures.Items.Armors;
using DnD5e.Creatures.Items.Weapons;
using DnD5e.Creatures.Items.WonderousItems;


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


        /// <summary>
        /// Returns this creature's wonderous items.
        /// </summary>
        IWonderousItem[] GetWonderousItems();

        /// <summary>
        /// Equips a wonderous item to this creature.
        /// </summary>
        /// <param name="wonderousItem">The wonderous item to equip.</param>
        void Equip(IWonderousItem wonderousItem);


        /// <summary>
        /// Returns this creature's manufactured weapons.
        /// </summary>
        IManufacturedWeapon[] GetWeapons();

        /// <summary>
        /// Equips a manufacturered weapon and registers it as an attack.
        /// </summary>
        /// <param name="weapon">The weapon to equip.</param>
        void Equip(IManufacturedWeapon weapon);
    }
}