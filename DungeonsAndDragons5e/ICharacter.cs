using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e
{
    /// <summary>
    /// A personality, such as an NPC.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// A set of stats which represent this character's raw talent and prowess.
        /// </summary>
        IAbilityScores AbilityScores { get; }
    }
}
