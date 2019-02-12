using System;


namespace DnD5e.Creatures.Items.Armors.Core
{
    /// <summary>
    /// An enhancement bonus to armor, such as +1, +2, or +3.
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
                    return Rarity.Rare;
                case 2:
                    return Rarity.VeryRare;
                case 3:
                    return Rarity.Legendary;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enhancementBonus), enhancementBonus, "1 <= enhancement bonus <= 3");
            }
        }
    }
}