using System;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.AbilityChecks.Skills
{
    internal sealed class SkillsSection : ISkillsSection
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.Skills.SkillSection"/> class.
        /// </summary>
        /// <param name="abilityScores">The ability scores to tie to skills.</param>
        /// <param name="proficiencyBonus">The character's proficiency bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SkillsSection(IAbilityScoresSection abilityScores, Func<byte> proficiencyBonus)
        {
            if (null == abilityScores)
                throw new ArgumentNullException(nameof(abilityScores), "Argument may not be null.");
            if (null == proficiencyBonus)
                throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");

            // Strength
            this.Athletics = new Skill(abilityScores?.Strength, proficiencyBonus);

            // Dexterity
            this.Acrobatics    = new Skill(abilityScores?.Dexterity, proficiencyBonus);
            this.SleightOfHand = new Skill(abilityScores?.Dexterity, proficiencyBonus);
            this.Stealth       = new Skill(abilityScores?.Dexterity, proficiencyBonus);

            // Consitution

            // Intelligence
            this.Arcana        = new Skill(abilityScores?.Intelligence, proficiencyBonus);
            this.History       = new Skill(abilityScores?.Intelligence, proficiencyBonus);
            this.Investigation = new Skill(abilityScores?.Intelligence, proficiencyBonus);
            this.Nature        = new Skill(abilityScores?.Intelligence, proficiencyBonus);
            this.Religion      = new Skill(abilityScores?.Intelligence, proficiencyBonus);


            // Wisdom
            this.AnimalHandling = new Skill(abilityScores?.Wisdom, proficiencyBonus);
            this.Insight        = new Skill(abilityScores?.Wisdom, proficiencyBonus);
            this.Medicine       = new Skill(abilityScores?.Wisdom, proficiencyBonus);
            this.Perception     = new Skill(abilityScores?.Wisdom, proficiencyBonus);
            this.Survival       = new Skill(abilityScores?.Wisdom, proficiencyBonus);

            // Charisma
            this.Deception    = new Skill(abilityScores?.Charisma, proficiencyBonus);
            this.Intimidation = new Skill(abilityScores?.Charisma, proficiencyBonus);
            this.Performance  = new Skill(abilityScores?.Charisma, proficiencyBonus);
            this.Persuasion   = new Skill(abilityScores?.Charisma, proficiencyBonus);
        }
        #endregion

        #region Properties
        public ISkill Acrobatics { get; }

        public ISkill AnimalHandling { get; }

        public ISkill Arcana { get; }

        public ISkill Athletics { get; }

        public ISkill Deception { get; }

        public ISkill History { get; }

        public ISkill Insight { get; }

        public ISkill Intimidation { get; }

        public ISkill Investigation { get; }

        public ISkill Medicine { get; }

        public ISkill Nature { get; }

        public ISkill Perception { get; }

        public ISkill Performance { get; }

        public ISkill Persuasion { get; }

        public ISkill Religion { get; }

        public ISkill SleightOfHand { get; }

        public ISkill Stealth { get; }

        public ISkill Survival { get; }
        #endregion
    }
}