using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndDragons5e.AbilityScores;
using DungeonsAndDragons5e.Dice;


namespace DungeonsAndDragons5e
{
    internal sealed class HitDice : IHitDice
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.HitDice"/> class.
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
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.HitDice"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.HitDice"/>.</returns>
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