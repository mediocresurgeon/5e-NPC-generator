using System;
using DnD5e.Creatures.Items.Armors;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Armors
{
    public class HeavyArmorTest
    {
        #region ApplyTo
        [Fact]
        public void ApplyTo_NullArg_Throws()
        {
            // Arrange
            ICreature character = null;
            var mockArmor = new Mock<HeavyArmor>() { CallBase = true };
            Armor armor = mockArmor.Object;

            // Act
            Action applyTo = () => armor.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }

        [Fact]
        public void ApplyTo_SetsArmorValueOfCharacter()
        {
            // Arrange
            var mockArmorClass = new Mock<IArmorClass>();
            var mockCharacter = new Mock<ICreature>();
            mockCharacter.Setup(c => c.ArmorClass)
                         .Returns(mockArmorClass.Object);

            var mockArmor = new Mock<HeavyArmor>() { CallBase = true };
            Armor armor = mockArmor.Object;

            // Act
            armor.ApplyTo(mockCharacter.Object);

            // Assert
            mockArmorClass.Verify(ac => ac.AddBase(It.IsAny<Func<byte>>()));
            mockArmorClass.Verify(ac => ac.AddMaxDex(It.Is<Func<byte>>(maxDex => 0 == maxDex())));
        }
        #endregion
    }
}