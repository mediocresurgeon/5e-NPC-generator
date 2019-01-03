namespace DnD5e.Creatures.AbilityScores
{
    internal sealed class AbilityScoresSection : IAbilityScoresSection
    {
        public IAbilityScore Strength     { get; } = new AbilityScore();

        public IAbilityScore Dexterity    { get; } = new AbilityScore();

        public IAbilityScore Constitution { get; } = new AbilityScore();

        public IAbilityScore Intelligence { get; } = new AbilityScore();

        public IAbilityScore Wisdom       { get; } = new AbilityScore();

        public IAbilityScore Charisma     { get; } = new AbilityScore();
    }
}