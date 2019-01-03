using System;
using DnD5e.Creatures.AbilityChecks;
using DnD5e.Creatures.AbilityChecks.Skills;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.SavingThrows;


namespace DnD5e.Creatures
{
    /// <summary>
    /// An entity which can take actions in combat, such as a monster or an NPC.
    /// </summary>
    public interface ICreature
    {
        /// <summary>
        /// A set of stats which represent this character's raw talent and prowess.
        /// </summary>
        IAbilityScoresSection AbilityScores { get; }

        /// <summary>
        /// Returns this character's armor class.
        /// </summary>
        IArmorClass ArmorClass { get; }

        /// <summary>
        /// Represents the durability of this character.
        /// </summary>
        IHitDice HitPoints { get; }

        /// <summary>
        /// An ability check which determines the order in which this character acts in combat.
        /// </summary>
        IAbilityCheck Initiative { get; }

        /// <summary>
        /// Calculates this character's proficiency bonus.
        /// </summary>
        Func<byte> GetProficiencyBonus { get; set; }

        /// <summary>
        /// This character's ability to resist harmful effects.
        /// </summary>
        ISavingThrowsSection SavingThrows { get; }

        /// <summary>
        /// A set of specialized ability checks.
        /// </summary>
        ISkillsSection Skills { get; }
    }
}