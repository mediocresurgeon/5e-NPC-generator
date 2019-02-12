using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.Attacks
{
    internal sealed class AttackBonusCalculator : IAttackBonusCalculator
    {
        #region Fields
        private sbyte? _totalAttackBonus;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Attacks.AttackBonusCalculator"/> class.
        /// </summary>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <param name="getKeyAbilityScore">The ability score which should be used when dynamically calculating this attack bonus.</param>
        public AttackBonusCalculator(Func<byte> proficiencyBonus, Func<IAbilityScore> getKeyAbilityScore)
        {
            this.ProficiencyBonus = proficiencyBonus ?? throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
            this.GetKeyAbilityScore = getKeyAbilityScore ?? throw new ArgumentNullException(nameof(getKeyAbilityScore), "Argument may not be null.");
        }
        #endregion

        #region Properties
        private Func<IAbilityScore> GetKeyAbilityScore { get; }

        private Func<byte> ProficiencyBonus { get; }

        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        public sbyte Total
        {
            get => _totalAttackBonus.HasValue ? SpecifiedAttackBonus() : DefaultAttackBonus();
            set => _totalAttackBonus = value;
        }
        #endregion

        #region Methods
        public void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }

        internal sbyte DefaultAttackBonus()
        {
            sbyte runningTotal = Convert.ToSByte(this.ProficiencyBonus());
            runningTotal += this.GetKeyAbilityScore().Modifer;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        internal sbyte SpecifiedAttackBonus()
        {
            sbyte runningTotal = _totalAttackBonus.Value;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }
        #endregion
    }
}