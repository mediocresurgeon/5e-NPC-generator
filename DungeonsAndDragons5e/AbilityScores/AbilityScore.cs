using System;


namespace DungeonsAndDragons5e.AbilityScores
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