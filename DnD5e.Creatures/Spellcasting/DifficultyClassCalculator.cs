using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// Calculates the DC of a spell.
    /// </summary>
    internal sealed class DifficultyClassCalculator : IDifficultyClassCalculator
    {
        #region Fields
        private sbyte? _totalDifficultyClass;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Spellcasting.DifficultyClassCalculator"/> class.
        /// </summary>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <param name="spellcastingStat">The creature's abiltiy score which is associated with spellcasting.</param>
        /// <exception cref="System.ArgumentNullException" />
        public DifficultyClassCalculator(Func<byte> proficiencyBonus, IAbilityScore spellcastingStat)
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
            get => _totalDifficultyClass.HasValue ? SpecifiedDifficultyClass() : DefaultDifficultyClass();
            set => _totalDifficultyClass = value;
        }
        #endregion

        #region Methods
        private sbyte DefaultDifficultyClass()
        {
            sbyte runningTotal = 8;
            runningTotal += Convert.ToSByte(this.ProficiencyBonus());
            runningTotal += this.SpellcastingStat.Modifer;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        private sbyte SpecifiedDifficultyClass()
        {
            sbyte runningTotal = _totalDifficultyClass.Value;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        /// <summary>
        /// Adds a modifier to this DC calculation.
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