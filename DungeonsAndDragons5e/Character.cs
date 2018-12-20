using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityChecks;
using DungeonsAndDragons5e.SavingThrows;

namespace DungeonsAndDragons5e
{
    /// <summary>
    /// A personality, such as an NPC.
    /// </summary>
    public sealed class Character : ICharacter
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.Character"/> class.
        /// </summary>
        public Character()
        {
            // local function so we don't have to define multiple anon functions
            byte getProf() => this.ProficiencyBonus;

            this.SavingThrows = new SavingThrowsSection(this.AbilityScores, getProf);
            this.Initiative   = new AbilityCheck(this.AbilityScores.Dexterity);
            this.Skills       = new SkillsSection(this.AbilityScores, getProf);
        }
        #endregion

        #region Properties
        /// <summary>
        /// This character's proficiency bonus.
        /// </summary>
        public byte ProficiencyBonus { get; set; } = 2;

        /// <summary>
        /// A set of stats which represent this character's raw talent and prowess.
        /// </summary>
        public IAbilityScoresSection AbilityScores { get; } = new AbilityScoresSection();

        /// <summary>
        /// A set of stats which indicate how resistant this character is to harmful effects.
        /// </summary>
        public ISavingThrowsSection SavingThrows { get; }

        /// <summary>
        /// An ability check which determines the order in which this character acts in combat.
        /// </summary>
        public IAbilityCheck Initiative { get; }

        /// <summary>
        /// A set of specialized ability checks.
        /// </summary>
        public ISkillsSection Skills { get; }
        #endregion
    }
}