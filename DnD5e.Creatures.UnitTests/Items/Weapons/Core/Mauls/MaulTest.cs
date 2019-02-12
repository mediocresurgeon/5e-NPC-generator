using DnD5e.Creatures.Attacks;
using DnD5e.Creatures.Items.Weapons.Core.Mauls;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core.Mauls
{
    public class MaulTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var weapon = new Maul();

            // Act
            var properties = weapon.GetProperties();

            // Assert
            Assert.Equal("Maul", weapon.Name);
            Assert.Equal(2, weapon.DamageDice.Quantity);
            Assert.Equal(6, weapon.DamageDice.Quality);
            Assert.Null(weapon.AlternateDamageDice);
            Assert.Equal(WeaponDamageType.Bludgeoning, weapon.DamageType);
            Assert.Equal(10, weapon.MarketValue);
            Assert.Equal(10, weapon.Weight);
            Assert.Contains(WeaponProperty.Heavy, properties);
            Assert.Contains(WeaponProperty.TwoHanded, properties);
            Assert.False(weapon.RangeIncrement1.HasValue);
            Assert.False(weapon.RangeIncrement2.HasValue);
        }
    }
}