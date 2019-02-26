using System;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// A creature's spells lots, which can be expended to cast spells.
    /// </summary>
    public interface ISpellSlots
    {
        /// <summary>
        /// The creature's caster level.
        /// </summary>
        Func<byte> CasterLevel { get; set; }

        /// <summary>
        /// Gets or sets the number of level 1 spell slots.
        /// </summary>
        byte Level1 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 2 spell slots.
        /// </summary>
        byte Level2 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 3 spell slots.
        /// </summary>
        byte Level3 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 4 spell slots.
        /// </summary>
        byte Level4 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 5 spell slots.
        /// </summary>
        byte Level5 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 6 spell slots.
        /// </summary>
        byte Level6 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 7 spell slots.
        /// </summary>
        byte Level7 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 8 spell slots.
        /// </summary>
        byte Level8 { get; set; }

        /// <summary>
        /// Gets or sets the number of level 9 spell slots.
        /// </summary>
        byte Level9 { get; set; }
    }
}