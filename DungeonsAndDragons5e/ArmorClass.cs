using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e
{
    internal sealed class ArmorClass : IArmorClass
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.ArmorClass"/> class.
        /// </summary>
        /// <param name="dexterity">The character's ability score which contributes </param>
        public ArmorClass(IAbilityScore dexterity)
        {
            this.Dexterity = dexterity ?? throw new ArgumentNullException(nameof(dexterity), "Argument may not be null.");
            this.AddBase(() => 10);
        }
        #endregion

        #region Properties
        private IAbilityScore Dexterity { get; }

        private List<Func<byte>> BaseArmorBonusTracker { get; } = new List<Func<byte>>();

        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        private List<Func<byte>> MaxDexBonus { get; } = new List<Func<byte>>();
        #endregion

        #region Methods
        public void AddBase(Func<byte> baseArmorBonus)
        {
            if (null == baseArmorBonus)
                throw new ArgumentNullException(nameof(baseArmorBonus), "Argument may not be null.");
            this.BaseArmorBonusTracker.Add(baseArmorBonus);
        }


        public void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }


        public void AddMaxDex(Func<byte> maxDex)
        {
            if (null == maxDex)
                throw new ArgumentNullException(nameof(maxDex), "Argument may not be null.");
            this.MaxDexBonus.Add(maxDex);
        }


        public sbyte GetTotal()
        {
            // Handle base armor bonus (usually 10)
            int runningTotal = this.BaseArmorBonusTracker.Max(baseArmor => baseArmor());

            // Handle dex-to-AC
            int dexToAc = this.Dexterity.Modifer;
            if (this.MaxDexBonus.Any())
            {
                var minVal = this.MaxDexBonus.Min(bon => bon());
                if (minVal < dexToAc)
                {
                    dexToAc = minVal;
                }
            }
            runningTotal += dexToAc;

            // Handle all other modifiers
            runningTotal += this.Modifiers.Sum(mod => mod());

            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}