using System;
using System.Linq;
using DnD5e.Creatures.Attacks;


namespace DnD5e.Creatures.Items.Weapons.Core
{
    /// <summary>
    /// An enhancement bonus to a weapon, such as +1, +2, or +3.
    /// </summary>
    internal static class EnhancementEnchantment
    {
        /// <summary>
        /// Determines the rarity of a give enhancement bonus.
        /// </summary>
        /// <returns>The rarity.</returns>
        /// <param name="enhancementBonus">The enhancement bonus.  Should be no less than 1 and no greater than 3.</param>
        /// <exception cref="System.ArgumentOutOfRangeException" />
        public static Rarity GetRarity(byte enhancementBonus)
        {
            switch (enhancementBonus)
            {
                case 1:
                    return Rarity.Uncommon;
                case 2:
                    return Rarity.Rare;
                case 3:
                    return Rarity.VeryRare;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enhancementBonus), enhancementBonus, "1 <= enhancement bonus <= 3");
            }
        }


        /// <summary>
        /// Applies the effects of a magically enhanced weapon to a character.
        /// </summary>
        /// <param name="weapon">The weapon which has been magically enhanced.</param>
        /// <param name="creature">The creature wielding the weapon.</param>
        /// <param name="enhancementBonus">The magnitude of the enhancement bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public static void ApplyTo(IWeapon weapon, ICreature creature, byte enhancementBonus)
        {
            if (null == weapon)
                throw new ArgumentNullException(nameof(weapon), "Argument may not be null.");
            if (null == creature)
                throw new ArgumentNullException(nameof(creature), "Argument may not be null.");
            foreach (var attackBlock in creature.GetAttacks().Where(ab => weapon == ab.Weapon))
            {
                sbyte enhBonus = Convert.ToSByte(enhancementBonus);
                attackBlock.AttackBonus.AddModifier(() => enhBonus);
                attackBlock.DamageBonus.AddModifier(() => enhBonus);
            }
        }
    }
}