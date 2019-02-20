using System;


namespace DnD5e.Creatures.Spells
{
    /// <summary>
    /// A spell, such as Magic Missile or Fireball.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// The name of this spell.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// This spell's level.
        /// Zero indicates this spell is a cantrip.
        /// </summary>
        byte Level { get; }

        /// <summary>
        /// Returns this spell's school of magic.
        /// </summary>
        School School { get; }

        /// <summary>
        /// The amount of time it takes to cast this spell.
        /// </summary>
        CastTime CastTime { get; }

        /// <summary>
        /// Indicates whether or not this spell requires concentration.
        /// </summary>
        bool RequiresConcentration { get; }

        /// <summary>
        /// Indicates whether or not this spell may be cast as a ritual.
        /// </summary>
        bool IsRitual { get; }

        /// <summary>
        /// The name of the book which published this spell.
        /// </summary>
        string SourceBook { get; }

        /// <summary>
        /// The page number on which this spell was published.
        /// May be inaccurate, since page numbers may shift during different printings.
        /// </summary>
        ushort PageNumber { get; }

        /// <summary>
        /// Not always available.
        /// A remote resource which describes this spell in detail.
        /// </summary>
        Uri Url { get; }

        /// <summary>
        /// Returns this spell's components.
        /// </summary>
        SpellComponent[] GetSpellComponents();
    }
}