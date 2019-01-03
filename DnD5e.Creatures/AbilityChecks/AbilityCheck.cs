using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.AbilityChecks
{
    internal class AbilityCheck : IAbilityCheck
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.AbilityChecks.AbilityCheck"/> class.
        /// </summary>
        /// <param name="abilityScore">The ability score associated with this ability check.</param>
        /// <exception cref="System.ArgumentNullException" />
        public AbilityCheck(IAbilityScore abilityScore)
        {
            this.AbilityScore = abilityScore ?? throw new ArgumentNullException(nameof(abilityScore), "Argument may not be null.");
            this.Modifiers.Add(() => this.AbilityScore.Modifer);
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
        /// <param name="modifier">The modifier to add.</param>
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
            return Convert.ToSByte(this.Modifiers.Select(f => Convert.ToDouble(f()))
                                                 .Sum());
        }
        #endregion
    }
}