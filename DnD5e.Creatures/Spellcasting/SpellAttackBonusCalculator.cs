using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// Calculates the attack bonus of a spell.
    /// </summary>
    internal sealed class SpellAttackBonusCalculator : IAttackBonusCalculator
    {
        #region Fields
        private sbyte? _totalAttackBonus;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Spellcasting.SpellAttackBonusCalculator"/> class.
        /// </summary>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <param name="spellcastingStat">The creature's abiltiy score which is associated with spellcasting.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SpellAttackBonusCalculator(Func<byte> proficiencyBonus, IAbilityScore spellcastingStat)
        {
            this.ProficiencyBonus = proficiencyBonus ?? throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
            this.SpellcastingStat = spellcastingStat ?? throw new ArgumentNullException(nameof(spellcastingStat), "Argument may not be null.");
        }
        #endregion

        #region Properties
        private Func<byte> ProficiencyBonus { get; }

        private IAbilityScore SpellcastingStat { get; }

        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public sbyte Total
        {
            get => _totalAttackBonus.HasValue ? SpecifiedAttackBonus() : DefaultAttackBonus();
            set => _totalAttackBonus = value;
        }
        #endregion

        #region Methods
        private sbyte DefaultAttackBonus()
        {
            sbyte runningTotal = Convert.ToSByte(this.ProficiencyBonus());
            runningTotal += this.SpellcastingStat.Modifer;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        private sbyte SpecifiedAttackBonus()
        {
            sbyte runningTotal = _totalAttackBonus.Value;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        /// <summary>
        /// Adds a modifier to this attack bonus calculation.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        /// <exception cref="System.ArgumentNullException" />
        public void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }
        #endregion
    }
}