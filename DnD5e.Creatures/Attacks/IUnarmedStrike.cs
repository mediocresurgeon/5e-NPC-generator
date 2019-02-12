namespace DnD5e.Creatures.Attacks
{
    /// <summary>
    /// A punch, kick, headbutt, or similar forceful blow.
    /// </summary>
    public interface IUnarmedStrike : IWeapon
    // By default, unarmed strikes are not natural weapons:
    // https://twitter.com/jeremyecrawford/status/756202441142444032?lang=en
    {
        // Intentionally blank.
    }
}