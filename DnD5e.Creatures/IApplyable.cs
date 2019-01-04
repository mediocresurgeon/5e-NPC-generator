namespace DnD5e.Creatures
{
    /// <summary>
    /// Allows an effect to be applied to an ICreature.
    /// </summary>
    public interface IApplyable
    {
        /// <summary>
        /// Modifies an ICreature.
        /// </summary>
        /// <param name="creature">The creature to modify.</param>
        void ApplyTo(ICreature creature);
    }
}