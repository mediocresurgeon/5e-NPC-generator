using DnD5e.Creatures.Attacks;
using DnD5e.Creatures.Items.Weapons.Core.Longbows;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core.Longbows
{
    public class LongbowTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var weapon = new Longbow();

            // Act
            var properties = weapon.GetProperties();

            // Assert
            Assert.Equal("Longbow", weapon.Name);
            Assert.Equal(1, weapon.DamageDice.Quantity);
            Assert.Equal(8, weapon.DamageDice.Quality);
            Assert.Null(weapon.AlternateDamageDice);
            Assert.Equal(WeaponDamageType.Piercing, weapon.DamageType);
            Assert.Equal(50, weapon.MarketValue);
            Assert.Equal(2, weapon.Weight);
            Assert.Contains(WeaponProperty.Heavy, properties);
            Assert.Contains(WeaponProperty.Range, properties);
            Assert.Contains(WeaponProperty.TwoHanded, properties);
            Assert.Equal(30, weapon.RangeIncrement1.Value);
            Assert.Equal(120, weapon.RangeIncrement2.Value);
        }
    }
}