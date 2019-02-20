using System;


namespace DnD5e.Creatures.Spells.Core
{
    /// <summary>
    /// The signature spell of the Warlock class.
    /// </summary>
    public sealed class EldritchBlast : ISpell
    {
        /// <summary>
        /// The name of this spell.
        /// </summary>
        public string Name => "Eldritch Blast";

        /// <summary>
        /// The level of this spell.
        /// </summary>
        public byte Level => 0;

        /// <summary>
        /// This spell's school of magic.
        /// </summary>
        /// <value>The school.</value>
        public School School => School.Evocation;

        /// <summary>
        /// The amount of time it takes to cast this spell.
        /// </summary>
        public CastTime CastTime => CastTime.Action;

        /// <summary>
        /// Indicates whether or not this spell requires concentration.
        /// </summary>
        public bool RequiresConcentration => false;

        /// <summary>
        /// Indicates whether or not this spell may be cast as a ritual.
        /// </summary>
        public bool IsRitual => false;

        /// <summary>
        /// The name of the book which published this spell.
        /// </summary>
        public string SourceBook => Book.PlayersHandbook;

        /// <summary>
        /// The page number on which this spell was published.
        /// May be inaccurate, since page numbers may shift during different printings.
        /// </summary>
        public ushort PageNumber => 237;

        /// <summary>
        /// Not always available.
        /// A remote resource which describes this spell in detail.
        /// </summary>
        public Uri Url => new Uri("https://roll20.net/compendium/dnd5e/Eldritch%20Blast#content");

        /// <summary>
        /// Returns this spell's components.
        /// </summary>
        public SpellComponent[] GetSpellComponents()
        {
            return new SpellComponent[] {
                SpellComponent.Verbal,
                SpellComponent.Somatic
            };
        }
    }
}