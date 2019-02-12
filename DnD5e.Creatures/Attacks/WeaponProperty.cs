namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// A property of a weapon, such as Finesse or Reach.
    /// </summary>
    public enum WeaponProperty
    {
        /// <summary>
        /// Small creatures have disadvantage on attack rolls with Heavy weapons.
        /// </summary>
        Heavy,

        /// <summary>
        /// When Making an Attack with a finesse weapon,
        /// you use your choice of your Strength or Dexterity modifier
        /// for the Attack and Damage Rolls.
        /// You must use the same modifier for both rolls.
        /// </summary>
        Finesse,

        /// <summary>
        /// A light weapon is small and easy to handle,
        /// making it ideal for use when fighting with two weapons.
        /// </summary>
        Light,

        /// <summary>
        /// Because of the time required to load this weapon,
        /// you can fire only one piece of ammunition from it
        /// when you use an action, bonus action, or reaction to fire it,
        /// regardless of the number of attacks you can normally make.
        /// </summary>
        Loading,

        /// <summary>
        /// Ranged weapons use Dexterity for attack and damage rolls.
        /// </summary>
        Range,

        /// <summary>
        /// This weapon adds 5 feet to your reach when you attack with it,
        /// as well as when determining your reach for opportunity attacks with it.
        /// </summary>
        Reach,

        /// <summary>
        /// If the weapon is a melee weapon, you use the same ability modifier
        /// for that attack roll and damage roll
        /// that you would use for a melee attack with the weapon.
        /// For example, if you throw a handaxe, you use your Strength,
        /// but if you throw a dagger, you can use either your Strength or your Dexterity,
        /// since the dagger has the finesse property.
        /// </summary>
        Thrown,

        /// <summary>
        /// This weapon requires two hands when you attack with it.
        /// </summary>
        TwoHanded,

        /// <summary>
        /// This weapon can be used with one or two hands.
        /// This may affect the weapon's damage.
        /// </summary>
        Versatile,
    }
}