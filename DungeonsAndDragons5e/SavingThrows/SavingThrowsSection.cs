using System;
using DungeonsAndDragons5e.AbilityScores;


namespace DungeonsAndDragons5e.SavingThrows
{
    internal sealed class SavingThrowsSection : ISavingThrowsSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DungeonsAndDragons5e.SavingThrows.SavingThrowSection"/> class.
        /// </summary>
        /// <param name="abilityScores">Ability scores.</param>
        /// <param name="proficiencyBonus">Proficiency bonus.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SavingThrowsSection(IAbilityScoresSection abilityScores, Func<byte> proficiencyBonus)
        {
            if (null == proficiencyBonus)
                throw new ArgumentNullException(nameof(proficiencyBonus), "Argument may not be null.");
            this.Strength     = new SavingThrow(abilityScores?.Strength, proficiencyBonus);
            this.Dexterity    = new SavingThrow(abilityScores?.Dexterity, proficiencyBonus);
            this.Constitution = new SavingThrow(abilityScores?.Constitution, proficiencyBonus);
            this.Intelligence = new SavingThrow(abilityScores?.Intelligence, proficiencyBonus);
            this.Wisdom       = new SavingThrow(abilityScores?.Wisdom, proficiencyBonus);
            this.Charisma     = new SavingThrow(abilityScores?.Charisma, proficiencyBonus);
        }
        #endregion

        #region Properties
        public ISavingThrow Strength { get; }

        public ISavingThrow Dexterity { get; }

        public ISavingThrow Constitution { get; }

        public ISavingThrow Intelligence { get; }

        public ISavingThrow Wisdom { get; }

        public ISavingThrow Charisma { get; }
        #endregion
    }
}