using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.AbilityChecks.Skills;
using DungeonsAndDragons5e.AbilityChecks;
using DungeonsAndDragons5e.SavingThrows;


namespace DungeonsAndDragons5e
{
    /// <summary>
    /// A personality, such as an NPC.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// This character's proficiency bonus.
        /// </summary>
        byte ProficiencyBonus { get; set; }

        /// <summary>
        /// A set of stats which represent this character's raw talent and prowess.
        /// </summary>
        IAbilityScoresSection AbilityScores { get; }

        /// <summary>
        /// This character's ability to resist harmful effects.
        /// </summary>
        ISavingThrowsSection SavingThrows { get; }

        /// <summary>
        /// An ability check which determines the order in which this character acts in combat.
        /// </summary>
        IAbilityCheck Initiative { get; }

        /// <summary>
        /// A set of specialized ability checks.
        /// </summary>
        ISkillsSection Skills { get; }

        /// <summary>
        /// Returns this character's armor class.
        /// </summary>
        IArmorClass ArmorClass { get; }
    }
}