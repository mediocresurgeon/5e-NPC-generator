using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Dice;


namespace DnD5e.Creatures
{
    internal sealed class HitDice : IHitDice
    {
        #region Fields
        private byte? _level;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.HitDice"/> class.
        /// </summary>
        /// <param name="constitution">A creature's consitution ability score.</param>
        /// <exception cref="System.ArgumentNullException" />
        public HitDice(IAbilityScore constitution)
        {
            this.AbilityScore = constitution ?? throw new ArgumentNullException(nameof(constitution), "Argument may not be null.");
            this.AddBonusHitPoints(() => Convert.ToSByte(this.AbilityScore.Modifer * this.Dice.Count));
        }
        #endregion

        #region Properties
        private IAbilityScore AbilityScore { get; }

        private IDiceBag Dice { get; } = new DiceBag();

        private List<Func<sbyte>> BonusHitPoints { get; } = new List<Func<sbyte>>();

        public byte HitDiceCount => this.Dice.Count;

        public byte Level
        {
            get => _level.HasValue ? _level.Value : this.HitDiceCount;
            set => _level = value;
        }

        public ushort Min
        {
            get
            {
                int subtotal = this.Dice.MinRoll + this.BonusHitPoints.Sum(f => f());
                return subtotal > this.HitDiceCount ? Convert.ToUInt16(subtotal) : this.HitDiceCount;
            }
        }

        public ushort Max => Convert.ToUInt16(this.Dice.MaxRoll + this.BonusHitPoints.Sum(f => f()));

        public ushort Avg => Convert.ToUInt16((this.Min + this.Max) / 2);
        #endregion

        #region Methods
        /// <summary>
        /// Adds bonus hit points.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public void AddBonusHitPoints(Func<sbyte> hitPoints)
        {
            if (null == hitPoints)
                throw new ArgumentNullException(nameof(hitPoints), "Argument may not be null.");
            this.BonusHitPoints.Add(hitPoints);
        }


        /// <summary>
        /// Adds hit dice.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public void AddHitDice(IDiceGroup hitDice)
        {
            if (null == hitDice)
                throw new ArgumentNullException(nameof(hitDice), "Argument may not be null.");
            this.Dice.Add(hitDice);
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:DnD5e.Creatures.HitDice"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:DnD5e.Creatures.HitDice"/>.</returns>
        public override string ToString()
        {
            var modifiers = this.BonusHitPoints.Select(f => f())
                                               .Where(t => t != 0);

            StringBuilder result = new StringBuilder(this.Dice.ToString());
            foreach (var negMod in modifiers.Where(m => m < 0))
            {
                result.Append($" - { Math.Abs(negMod) }");
            }
            foreach (var posMod in modifiers.Where(m => m > 0))
            {
                result.Append($" + { posMod }");
            }

            return result.ToString();
        }
        #endregion
    }
}