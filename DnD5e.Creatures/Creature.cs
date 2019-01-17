using System;
using System.Collections.Generic;
using DnD5e.Creatures.AbilityChecks;
using DnD5e.Creatures.AbilityChecks.Skills;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.SavingThrows;


namespace DnD5e.Creatures
{
    /// <summary>
    /// An entity which can take actions in combat, such as a monster or an NPC.
    /// </summary>
    public sealed class Creature : ICreature
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Creature"/> class.
        /// </summary>
        public Creature()
        {
            this.ArmorClass = new ArmorClass(this.AbilityScores.Dexterity);
            this.HitPoints = new HitDice(this.AbilityScores.Constitution);
            this.Initiative = new AbilityCheck(this.AbilityScores.Dexterity);

            this.GetProficiencyBonus = () => GetProficiencyBonusFromLevel(this.HitPoints.HitDiceCount);
            this.SavingThrows = new SavingThrowsSection(this.AbilityScores, () => this.GetProficiencyBonus());
            this.Skills = new SkillsSection(this.AbilityScores, () => this.GetProficiencyBonus());

            this.Equipment = new EquipmentSection(this);
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

        /// <summary>
        /// Returns this creature's equipment.
        /// </summary>
        public IEquipmentSection Equipment { get; }
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