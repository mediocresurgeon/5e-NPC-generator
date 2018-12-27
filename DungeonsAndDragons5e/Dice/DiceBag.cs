using System;
using System.Collections.Generic;
using System.Linq;


namespace DungeonsAndDragons5e.Dice
{
    internal sealed class DiceBag : IDiceBag
    {
        #region Properties
        private List<DiceGroup> Dice { get; } = new List<DiceGroup>();

        /// <summary>
        /// Returns the number of dice in this <see cref="T:DungeonsAndDragons5e.Dice.DiceBag"/>.
        /// </summary>
        public byte Count => this.Dice.Any() ? Convert.ToByte(this.Dice.Sum(dg => dg.Quantity)) : (byte) 0;

        /// <summary>
        /// Returns the minimum possible value for a roll of these dice.
        /// </summary>
        /// <value>The value of the minimum roll.</value>
        public byte MinRoll => this.Dice.Any() ? Convert.ToByte(this.Dice.Sum(dg => dg.Quantity)) : (byte)0;

        /// <summary>
        /// Returns the maximum possible value for a roll of these dice.
        /// </summary>
        /// <value>The value of the maximum roll.</value>
        public byte MaxRoll => this.Dice.Any() ? Convert.ToByte(this.Dice.Sum(dg => dg.Quality * dg.Quantity)) : (byte)0;
        #endregion

        #region Methods
        /// <summary>
        /// Adds dice into this <see cref="T:DungeonsAndDragons5e.Dice.DiceBag"/>.
        /// </summary>
        /// <param name="dice">The dice to add.</param>
        public void Add(IDiceGroup dice)
        {
            if (null == dice)
                return;

            // If there is already a set of dice of the same quality, update the number.
            for (int i = 0; i < this.Dice.Count; i++)
            {
                if (this.Dice[i].Quality == dice.Quality)
                {
                    byte quantity = Convert.ToByte(this.Dice[i].Quantity + dice.Quantity);
                    this.Dice[i] = new DiceGroup(quantity, this.Dice[i].Quality);
                    return;
                }
            }

            // Otherwise, add the new quality of dice to the mix.
            this.Dice.Add(new DiceGroup(dice.Quantity, dice.Quality));
        }


        /// <summary>
        /// Rolls the dice in this <see cref="T:DungeonsAndDragons5e.Dice.DiceBag"/>.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        /// <returns>The result of the roll.</returns>
        /// <exception cref="System.ArgumentNullException" />
        public byte Roll(Random random)
        {
            if (null == random)
                throw new ArgumentNullException(nameof(random), "Argument may not be null.");

            byte runningTotal = 0;
            foreach (var dicegroup in this.Dice)
            {
                runningTotal += dicegroup.Roll(random);
            }
            return runningTotal;
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.Dice.DiceBag"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.Dice.DiceBag"/>.</returns>
        public override string ToString()
        {
            return String.Join(" + ", this.Dice.OrderByDescending(dg => dg.Quantity)
                                               .ThenByDescending(dg => dg.Quality)
                                               .Select(dg => dg.ToString()));
        }
        #endregion
    }
}