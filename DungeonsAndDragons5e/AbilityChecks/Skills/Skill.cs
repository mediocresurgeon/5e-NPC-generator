using System;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.AbilityChecks.Skills
{
    internal sealed class Skill : AbilityCheck, ISkill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.AbilityChecks.Skills.Skill"/> class.
        /// </summary>
        /// <param name="abilityScore">The ability score associated with this skill.</param>
        /// <param name="proficiencyBonus">The character's proficiency bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public Skill(IAbilityScore abilityScore, Func<byte> proficiencyBonus)
            : base(abilityScore)
        {
            if (null == proficiencyBonus)
                throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
            this.AddModifier(() => this.IsProficient ? Convert.ToSByte(proficiencyBonus()) : (sbyte)0);
        }

        /// <summary>
        /// Indicates whether or not the character is proficient in this skill.
        /// </summary>
        public bool IsProficient { get; set; }
    }
}