using DnD5e.Creatures.Items.Armors.Core.PaddedArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.PaddedArmors
{
    public class PaddedArmorTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new PaddedArmor();

            // Act

            // Assert
            Assert.Equal("Padded Armor", armor.Name);
            Assert.Equal(11, armor.BaseArmorValue);
            Assert.Equal(5, armor.MarketValue.Value);
            Assert.Equal(8, armor.Weight);
        }
    }
}