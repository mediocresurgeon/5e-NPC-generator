using System;
using System.Collections.Generic;
using System.Linq;
using DnD5e.Creatures.AbilityScores;


namespace DnD5e.Creatures.Attacks
{
    internal sealed class AttackBlock : IAttackBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Attacks.AttackBlock"/> class.
        /// </summary>
        /// <param name="strength">The creature's Strength score.</param>
        /// <param name="dexterity">The creature's Dexterity score.</param>
        /// <param name="proficiencyBonus">The creature's proficiency bonus.</param>
        /// <param name="weapon">The weapon for which this attack block applies.</param>
        /// <exception cref="System.ArgumentNullException" />
        public AttackBlock(IAbilityScore strength, IAbilityScore dexterity, Func<byte> proficiencyBonus, IWeapon weapon)
        {
            this.Strength = strength ?? throw new ArgumentNullException(nameof(strength), "Argument may not be null.");
            this.Dexterity = dexterity ?? throw new ArgumentNullException(nameof(dexterity), "Argument may not be null.");
            this.Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon), "Argument may not be null.");

            this.AttackBonus = new AttackBonusCalculator(proficiencyBonus, this.GetKeyAbilityScore);
            this.DamageBonus = new DamageBonusCalculator(this.GetKeyAbilityScore);
        }

        #region Properties
        private IAbilityScore Strength { get; }

        private IAbilityScore Dexterity { get; }

        private List<IAbilityScore> CandidateAbilityScores { get; } = new List<IAbilityScore>();

        public IWeapon Weapon { get; }

        public IAttackBonusCalculator AttackBonus { get; }

        public IDamageBonusCalculator DamageBonus { get; }
        #endregion

        #region Methods
        public void AddCandidateAbilityScore(IAbilityScore abilityScore)
        {
            if (null == abilityScore)
                throw new ArgumentNullException(nameof(abilityScore), "Argument may not be null.");
            if (this.CandidateAbilityScores.Contains(abilityScore))
                return;
            this.CandidateAbilityScores.Add(abilityScore);
        }


        public IAbilityScore GetKeyAbilityScore()
        {
            // By default, weapons use strength for attack/damage
            IAbilityScore keyAbilityScore = this.Strength;

            // Check weapon properties for special cases
            var weaponProperties = this.Weapon.GetProperties();

            // Ranged weapons always use Dexterity
            if (weaponProperties.Contains(WeaponProperty.Range))
            {
                keyAbilityScore = this.Dexterity;
            }
            // Finesse weapons use Dexterity instead of Strength if it is advantageous to do so
            else if (weaponProperties.Contains(WeaponProperty.Finesse)
                     && keyAbilityScore.Score < this.Dexterity.Score)
            {
                keyAbilityScore = this.Dexterity;
            }

            // Finally, check other candidates and use them if they are higher
            foreach (IAbilityScore candidate in this.CandidateAbilityScores)
            {
                if (keyAbilityScore.Score < candidate.Score)
                {
                    keyAbilityScore = candidate;
                }
            }

            return keyAbilityScore;
        }
        #endregion
    }
}