using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.Attacks
{
    internal sealed class DamageBonusCalculator : IDamageBonusCalculator
    {
        #region Fields
        private sbyte? _totalDamageBonus;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Attacks.DamageBonusCalculator"/> class.
        /// </summary>
        /// <param name="getKeyAbilityScore">A function which returns the ability score which powers damage.</param>
        /// <exception cref="System.ArgumentNullException" />
        public DamageBonusCalculator(Func<IAbilityScore> getKeyAbilityScore)
        {
            this.GetKeyAbilityScore = getKeyAbilityScore ?? throw new ArgumentNullException(nameof(getKeyAbilityScore), "Argument may not be null.");
        }
        #endregion

        #region Properties
        private Func<IAbilityScore> GetKeyAbilityScore { get; }

        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        public sbyte Total
        {
            get => _totalDamageBonus.HasValue ? SpecifiedDamageBonus() : DefaultDamageBonus();
            set => _totalDamageBonus = value;
        }
        #endregion

        #region Methods
        public void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }


        internal sbyte DefaultDamageBonus()
        {
            sbyte runningTotal = this.GetKeyAbilityScore().Modifer;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }


        internal sbyte SpecifiedDamageBonus()
        {
            sbyte runningTotal = _totalDamageBonus.Value;
            if (this.Modifiers.Any())
            {
                runningTotal += Convert.ToSByte(this.Modifiers.Sum(mod => mod()));
            }
            return runningTotal;
        }
        #endregion
    }
}