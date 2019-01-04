namespace DnD5e.Creatures.Items.Armors
{
    /// <summary>
    /// Armor which provides more protection that light armor, but impairs one's movement more.
    /// </summary>
    public abstract class MediumArmor : Armor, IMediumArmor
    {
        /// <summary>
        /// Applies the effects of this armor to the creature who is wearing it.
        /// </summary>
        /// <param name="creature">The creature who is wearing this armor.</param>
        /// <exception cref="System.ArgumentNullException" />
        public override void ApplyTo(ICreature creature)
        {
            base.ApplyTo(creature);
            creature.ArmorClass.AddMaxDex(() => 2);
        }
    }
}