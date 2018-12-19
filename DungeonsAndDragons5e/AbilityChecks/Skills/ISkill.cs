namespace DungeonsAndDragons5e.AbilityChecks.Skills
{
    /// <summary>
    /// A specialized ability check.
    /// </summary>
    public interface ISkill : IAbilityCheck
    {
        /// <summary>
        /// Indicates whether or not the character is proficient in this skill.
        /// </summary>
        bool IsProficient { get; set; }
    }
}