using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.AbilityChecks
{
    internal class AbilityCheck : IAbilityCheck
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.AbilityChecks.AbilityCheck"/> class.
        /// </summary>
        /// <param name="abilityScore">The ability score associated with this ability check.</param>
        /// <exception cref="System.ArgumentNullException" />
        public AbilityCheck(IAbilityScore abilityScore)
        {
            this.AbilityScore = abilityScore ?? throw new ArgumentNullException(nameof(abilityScore), "Argument may not be null.");
        }
        #endregion

        #region Properties
        /// <summary>
        /// The modifiers to this ability check.
        /// </summary>
        private List<Func<sbyte>> Modifiers { get; } = new List<Func<sbyte>>();

        /// <summary>
        /// The ability score associated with this ability check.
        /// </summary>
        public IAbilityScore AbilityScore { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the modifier.
        /// </summary>
        /// <param name="modifier">Modifier.</param>
        /// <exception cref="System.ArgumentNullException" />
        public virtual void AddModifier(Func<sbyte> modifier)
        {
            if (null == modifier)
                throw new ArgumentNullException(nameof(modifier), "Argument may not be null.");
            this.Modifiers.Add(modifier);
        }

        /// <summary>
        /// Gets the total modifier for this ability check.
        /// </summary>
        /// <returns>The total.</returns>
        public virtual sbyte GetTotal()
        {
            double runningTotal = this.AbilityScore.Modifer;
            if (this.Modifiers.Any())
            {
                runningTotal += this.Modifiers.Select(f => Convert.ToDouble(f()))
                                              .Sum();
            }
            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}