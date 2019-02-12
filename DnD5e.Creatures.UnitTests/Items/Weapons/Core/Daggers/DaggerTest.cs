using System;
using DnD5e.Creatures.Attacks;
using DnD5e.Creatures.Dice;
using DnD5e.Creatures.Items.Weapons.Core.Daggers;
using Xunit;

namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core.Daggers
{
    public class DaggerTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var weapon = new Dagger();

            // Act
            var properties = weapon.GetProperties();

            // Assert
            Assert.Equal("Dagger", weapon.Name);
            Assert.Equal(1, weapon.DamageDice.Quantity);
            Assert.Equal(4, weapon.DamageDice.Quality);
            Assert.Null(weapon.AlternateDamageDice);
            Assert.Equal(WeaponDamageType.Piercing, weapon.DamageType);
            Assert.Equal(2, weapon.MarketValue);
            Assert.Equal(1, weapon.Weight);
            Assert.Contains(WeaponProperty.Finesse, properties);
            Assert.Contains(WeaponProperty.Light, properties);
            Assert.Contains(WeaponProperty.Thrown, properties);
            Assert.Equal(4, weapon.RangeIncrement1.Value);
            Assert.Equal(15, weapon.RangeIncrement2.Value);
        }
    }
}