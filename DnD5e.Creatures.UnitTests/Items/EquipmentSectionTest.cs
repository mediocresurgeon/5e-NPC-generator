using System;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Armors;
using DnD5e.Creatures.Items.Weapons;
using DnD5e.Creatures.Items.WonderousItems;
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
            mockArmor.Verify(a => a.ApplyTo(It.Is<ICreature>(arg => arg == character)),
                             Times.Once);
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

        #region Spellbook
        [Fact]
        public void Equip_NullSpellbook_Throws()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            ISpellbook spellbook = null;

            // Act
            Action equip = () => equipment.Equip(spellbook);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Fact]
        public void Equip_Spellbook_HappyPath()
        {
            // Arrange
            var mockCharacter = new Mock<ICreature>();
            var character = mockCharacter.Object;

            var mockApplyable = new Mock<IApplyable>();
            var mockSpellbook = mockApplyable.As<ISpellbook>();
            var spellbook = mockSpellbook.Object;

            var equipment = new EquipmentSection(character);

            // Act
            equipment.Equip(spellbook);

            // Assert
            Assert.Same(spellbook, equipment.Spellbook);
            mockApplyable.Verify(a => a.ApplyTo(It.Is<ICreature>(arg => arg == character)),
                                 Times.Once);
        }


        [Fact]
        public void Equip_Spellbook_CannotEquipTwoSpellbooks()
        {
            // Arrange
            var spellbook1 = Mock.Of<ISpellbook>();
            var spellbook2 = Mock.Of<ISpellbook>();
            var equipment = new EquipmentSection(Mock.Of<ICreature>());

            // Act
            equipment.Equip(spellbook1);
            Action secondEquip = () => equipment.Equip(spellbook2);

            // Assert
            Assert.Throws<InvalidOperationException>(secondEquip);
        }


        [Fact]
        public void Equip_RedundantSpellbook_AppliedOnlyOnce()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            var mockApplyable = new Mock<IApplyable>();
            var mockSpellbook = mockApplyable.As<ISpellbook>();
            var spellbook = mockSpellbook.Object;

            // Act
            equipment.Equip(spellbook);

            // Assert
            mockApplyable.Verify(a => a.ApplyTo(It.IsAny<ICreature>()),
                                 Times.Once);
        }
        #endregion

        #region Weapon
        [Fact]
        public void Equip_NullWeapon_Throws()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            IManufacturedWeapon weapon = null;

            // Act
            Action equip = () => equipment.Equip(weapon);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Fact]
        public void Equip_Weapon_HappyPath()
        {
            // Arrange
            var mockCharacter = new Mock<ICreature>();
            var character = mockCharacter.Object;

            var equipment = new EquipmentSection(character);

            var mockApplyable = new Mock<IApplyable>();
            var mockWeapon = mockApplyable.As<IManufacturedWeapon>();
            var weapon = mockWeapon.Object;

            // Act
            equipment.Equip(weapon);

            // Assert
            Assert.Contains(weapon, equipment.GetWeapons());
            mockCharacter.Verify(c => c.AddAttack(It.Is<IManufacturedWeapon>(arg => arg == weapon)),
                                 Times.Once);
            mockApplyable.Verify(a => a.ApplyTo(It.Is<ICreature>(arg => arg == character)),
                                 Times.Once);
        }


        [Fact]
        public void Equip_RedundantWeapon_AppliedOnlyOnce()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());

            var mockApplyable = new Mock<IApplyable>();
            var mockWeapon = mockApplyable.As<IManufacturedWeapon>();
            var weapon = mockWeapon.Object;

            // Act
            equipment.Equip(weapon);
            equipment.Equip(weapon);

            // Assert
            mockApplyable.Verify(a => a.ApplyTo(It.IsAny<ICreature>()),
                                 Times.Once);
        }
        #endregion

        #region Wonderous Items
        [Fact]
        public void Equip_NullWonderousItem_Throws()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());
            IWonderousItem item = null;

            // Act
            Action equip = () => equipment.Equip(item);

            // Assert
            Assert.Throws<ArgumentNullException>(equip);
        }


        [Fact]
        public void Equip_WonderousItem_HappyPath()
        {
            // Arrange
            var mockCharacter = new Mock<ICreature>();
            var character = mockCharacter.Object;

            var equipment = new EquipmentSection(character);

            var mockApplyable = new Mock<IApplyable>();
            var mockItem = mockApplyable.As<IWonderousItem>();
            var item = mockItem.Object;

            // Act
            equipment.Equip(item);

            // Assert
            Assert.Contains(item, equipment.GetWonderousItems());
            mockApplyable.Verify(a => a.ApplyTo(It.Is<ICreature>(arg => arg == character)),
                                 Times.Once);
        }


        [Fact]
        public void Equip_RedundantWonderousItem_AppliedOnlyOnce()
        {
            // Arrange
            var equipment = new EquipmentSection(Mock.Of<ICreature>());

            var mockApplyable = new Mock<IApplyable>();
            var mockItem = mockApplyable.As<IWonderousItem>();
            var item = mockItem.Object;

            // Act
            equipment.Equip(item);
            equipment.Equip(item);

            // Assert
            mockApplyable.Verify(a => a.ApplyTo(It.IsAny<ICreature>()),
                                 Times.Once);
        }
        #endregion
    }
}