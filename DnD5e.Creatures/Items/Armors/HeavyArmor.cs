namespace DnD5e.Creatures.Items.Armors
{
    /// <summary>
    /// A suit of armor which covers the entire body and is designed to stop a wide range of attacks.
    /// </summary>
    public abstract class HeavyArmor : Armor, IHeavyArmor
    {
        /// <summary>
        /// Applies the effects of this armor to the creature who is wearing it.
        /// </summary>
        /// <param name="creature">The creature who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException" />
        public override void ApplyTo(ICreature creature)
        {
            base.ApplyTo(creature);
            creature.ArmorClass.AddMaxDex(() => 0);
        }
    }
}