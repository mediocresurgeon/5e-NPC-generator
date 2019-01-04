using DnD5e.Creatures.Items.Armors.Core.RingMails;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors.Core.RingMails
{
    public class RingMailTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var armor = new RingMail();

            // Act

            // Assert
            Assert.Equal("Ring Mail", armor.Name);
            Assert.Equal(14, armor.BaseArmorValue);
            Assert.Equal(30, armor.MarketValue.Value);
            Assert.Equal(40, armor.Weight);
        }
    }
}
