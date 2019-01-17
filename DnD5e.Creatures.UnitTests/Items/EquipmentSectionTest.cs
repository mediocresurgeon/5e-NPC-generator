using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items
{
    public class EquipmentSectionTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullCreature_Throws()
        {
            // Arrange
            ICreature character = null;

            // Act
            Action constructor = () => new EquipmentSection(character);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Armor
        [Fact]
        public void Equip_NullArmor_Throws()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            IArmor armor = null;

            // Act
            Action equip = () => equipment.Equip(armor);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Fact]
        public void Equip_Armor_HappyPath()
        {
            // Arrange
            var character = Mock.Of<ICreature>();

            var equipment = new EquipmentSection(character);

            var mockArmor = new Mock<IArmor>();
            var armor = mockArmor.Object;

            // Act
            equipment.Equip(armor);

            // Assert
            Assert.Same(armor, equipment.Armor);
            mockArmor.Verify(a => a.ApplyTo(It.Is<ICreature>(arg => arg == character)));
        }


        [Fact]
        public void Equip_Armor_CannotEquipTwoArmors()
        {
            // Arrange
            var armor1 = Mock.Of<IArmor>();
            var armor2 = Mock.Of<IArmor>();
            var equipment = new EquipmentSection(Mock.Of<ICreature>());

            // Act
            equipment.Equip(armor1);
            Action secondEquip = () => equipment.Equip(armor2);

            // Assert
            Assert.Throws<InvalidOperationException>(secondEquip);
        }


        [Fact]
        public void Equip_RedundantArmor_AppliedOnlyOnce()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            var armor = new Mock<IArmor>();
            equipment.Equip(armor.Object);

            // Act
            equipment.Equip(equipment.Armor);

            // Assert
            armor.Verify(a => a.ApplyTo(It.IsAny<ICreature>()),
                         Times.Once);
        }
        #endregion
    }
}