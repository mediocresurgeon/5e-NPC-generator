using System;


namespace DnD5e.Creatures.AbilityScores
{
    internal sealed class AbilityScore : IAbilityScore
    {
        public byte Score { get; set; } = 10;

        public sbyte Modifer
        {
            get
            {
                double temp = this.Score;
                temp = Math.Floor((temp - 10) / 2);
                return Convert.ToSByte(temp);
            }
        }
    }
}