using System;


namespace DungeonsAndDragons5e.Dice
{
    /// <summary>
    /// Represents a set of dice, such as 1d4 or 2d6.
    /// </summary>
    internal struct DiceGroup : IDiceGroup
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/> struct.
        /// </summary>
        /// <param name="quantity">The number of dice in this <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.</param>
        /// <param name="quality">The number of faces on each die in this <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.</param>
        /// <exception cref="System.ArgumentOutOfRangeException" />
        internal DiceGroup(byte quantity, byte quality)
        {
            if (1 > quality)
                throw new ArgumentOutOfRangeException(nameof(quality), "Dice quality may not be less than 1.");
            this.Quantity = quantity;
            this.Quality = quality;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The number of dice in this <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        public byte Quantity { get; }


        /// <summary>
        /// The number of sides on each of the dice in this <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        public byte Quality { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Rolls the dice in this <see cref="T:DungeonsAndDragons5e.Dice.IDiceGroup"/>.
        /// </summary>
        /// <param name="random">A random number generator.</param>
        /// <returns>The sum of the resultant die faces.</returns>
        /// <exception cref="System.ArgumentNullException" />
        public byte Roll(Random random)
        {
            if (null == random)
                throw new ArgumentNullException(nameof(random), "Argument may not be null.");
            int runningTotal = 0;
            for (var i = 0; i < this.Quantity; i++)
            {
                runningTotal += random.Next(1, this.Quality);
            }
            return Convert.ToByte(runningTotal);
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.</returns>
        public override string ToString()
        {
            if (this.Quality == 1)
                return this.Quantity.ToString();
            return $"{ this.Quantity }d{ this.Quality }";
        }

        #region Equality
        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as IDiceGroup);
        }


        /// <summary>
        /// Determines whether the specified <see cref="DungeonsAndDragons5e.Dice.IDiceGroup"/> is equal to the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="other">The <see cref="DungeonsAndDragons5e.Dice.IDiceGroup"/> to compare with the current <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="DungeonsAndDragons5e.Dice.IDiceGroup"/> is equal to the current
        /// <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(IDiceGroup other)
        {
            // If parameter is null, return false.
            if (other is null) {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other)) {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType()) {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (this.Quality == other.Quality) && (this.Quantity == other.Quantity);
        }


        /// <summary>
        /// Serves as a hash function for a <see cref="T:DungeonsAndDragons5e.Dice.DiceGroup"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return this.Quantity ^ this.Quality;
        }


        /// <summary>
        /// Determines whether a specified instance of <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> is equal to
        /// another specified <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="lhs">The first <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> to compare.</param>
        /// <param name="rhs">The second <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> to compare.</param>
        /// <returns><c>true</c> if <c>lhs</c> and <c>rhs</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(DiceGroup lhs, DiceGroup rhs)
        {
            return lhs.Equals(rhs);
        }


        /// <summary>
        /// Determines whether a specified instance of <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> is not equal to
        /// another specified <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/>.
        /// </summary>
        /// <param name="lhs">The first <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> to compare.</param>
        /// <param name="rhs">The second <see cref="DungeonsAndDragons5e.Dice.DiceGroup"/> to compare.</param>
        /// <returns><c>true</c> if <c>lhs</c> and <c>rhs</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(DiceGroup lhs, DiceGroup rhs)
        {
            return !(lhs.Equals(rhs));
        }
        #endregion
        #endregion
    }
}