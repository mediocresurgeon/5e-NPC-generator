using DnD5e.Creatures.Items.Armors.Core.HideArmors;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.HideArmors
{
    public class HideArmorTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new HideArmor();

            // Act

            // Assert
            Assert.Equal("Hide Armor", armor.Name);
            Assert.Equal(12, armor.BaseArmorValue);
            Assert.Equal(10, armor.MarketValue.Value);
            Assert.Equal(12, armor.Weight);
        }
    }
}