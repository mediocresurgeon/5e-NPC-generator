using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.SavingThrows
{
    internal sealed class SavingThrow : ISavingThrow
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.SavingThrows.SavingThrow"/> class.
        /// </summary>
        /// <param name="abilityScore">The ability score associated with this saving throw.</param>
        /// <param name="proficiencyBonus">The character's proficiency bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SavingThrow(IAbilityScore abilityScore, Func<byte> proficiencyBonus)
        {
            if (null == abilityScore)
                throw new ArgumentNullException(nameof(abilityScore), "Argument may not be null.");
            if (null == proficiencyBonus)
                throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
            this.AddModifier(() => abilityScore.Modifer);
            this.AddModifier(() => this.IsProficient ? Convert.ToSByte(proficiencyBonus()) : (sbyte)0);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The modifiers to this ability check.
        /// </summary>
        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        /// <summary>
        /// Indicates whether or not the character is proficient in this saving throw.
        /// </summary>
        public bool IsProficient { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the modifier.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }


        /// <summary>
        /// Gets the total modifier for this ability check.
        /// </summary>
        /// <returns>The total.</returns>
        public sbyte GetTotal()
        {
            return Convert.ToSByte(this.Modifiers.Select(f => Convert.ToDouble(f()))
                                                 .Sum());
        }
        #endregion
    }
}
