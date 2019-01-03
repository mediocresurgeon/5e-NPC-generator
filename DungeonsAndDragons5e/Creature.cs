using System;
using DungeonsAndDragons5e.AbilityChecks;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.SavingThrows;


namespace DungeonsAndDragons5e
{
    /// <summary>
    /// An entity which can take actions in combat, such as a monster or an NPC.
    /// </summary>
    public sealed class Creature : ICreature
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.Creature"/> class.
        /// </summary>
        public Creature()
        {
            this.ArmorClass = new ArmorClass(this.AbilityScores.Dexterity);
            this.HitPoints  = new HitDice(this.AbilityScores.Constitution);
            this.Initiative = new AbilityCheck(this.AbilityScores.Dexterity);

            this.GetProficiencyBonus = () => GetProficiencyBonusFromLevel(this.HitPoints.HitDiceCount);
            this.SavingThrows        = new SavingThrowsSection(this.AbilityScores, () => this.GetProficiencyBonus());
            this.Skills              = new SkillsSection(this.AbilityScores, () => this.GetProficiencyBonus());
        }
        #endregion

        #region Properties
        /// <summary>
        /// A set of stats which represent this character's raw talent and prowess.
        /// </summary>
        public IAbilityScoresSection AbilityScores { get; } = new AbilityScoresSection();

        /// <summary>
        /// A measurement of how difficult this character is to hit.
        /// </summary>
        public IArmorClass ArmorClass { get; }

        /// <summary>
        /// The durability of this character.
        /// </summary>
        public IHitDice HitPoints { get; }

        /// <summary>
        /// An ability check which determines the order in which this character acts in combat.
        /// </summary>
        public IAbilityCheck Initiative { get; }

        /// <summary>
        /// Calculates this character's proficiency bonus.
        /// </summary>
        public Func<byte> GetProficiencyBonus { get; set; }

        /// <summary>
        /// A set of stats which indicate how resistant this character is to harmful effects.
        /// </summary>
        public ISavingThrowsSection SavingThrows { get; }

        /// <summary>
        /// A set of specialized ability checks.
        /// </summary>
        public ISkillsSection Skills { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Given a level, determines the proficiency bonus.
        /// </summary>
        /// <param name="level">The character's level.</param>
        /// <returns>The proficiency bonus.</returns>
        internal static byte GetProficiencyBonusFromLevel(byte level)
        {
            return Convert.ToByte(((level - 1) / 4) + 2);
        }
        #endregion
    }
}