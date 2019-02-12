using System;
using DnD5e.Creatures.Attacks;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.Weapons.Core;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.Weapons.Core
{
    public class EnhancementEnchantmentTest
    {
        #region GetRarity
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void GetRarity_BadArg_Throws(byte enhancementBonus)
        {
            // Arrange

            // Act
            Action getRarity = () => EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(getRarity);
        }


        [Fact]
        public void GetRarity_PlusOne_Rare()
        {
            // Arrange
            byte enhancementBonus = 1;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.Uncommon, result);
        }


        [Fact]
        public void GetRarity_PlusTwo_Rare()
        {
            // Arrange
            byte enhancementBonus = 2;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.Rare, result);
        }


        [Fact]
        public void GetRarity_PlusThree_Rare()
        {
            // Arrange
            byte enhancementBonus = 3;

            // Act
            var result = EnhancementEnchantment.GetRarity(enhancementBonus);

            // Assert
            Assert.Equal(Rarity.VeryRare, result);
        }
        #endregion

        #region ApplyTo
        [Fact]
        public void ApplyTo_NullWeapon_Throws()
        {
            // Arrange
            IWeapon weapon = null;
            ICreature character = Mock.Of<ICreature>();
            byte enhancementBonus = 1;

            // Act
            Action applyTo = () => EnhancementEnchantment.ApplyTo(weapon, character, enhancementBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Fact]
        public void ApplyTo_NullCreature_Throws()
        {
            // Arrange
            IWeapon weapon = Mock.Of<IWeapon>();
            ICreature character = null;
            byte enhancementBonus = 1;

            // Act
            Action applyTo = () => EnhancementEnchantment.ApplyTo(weapon, character, enhancementBonus);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Fact]
        public void ApplyTo_HappyPath()
        {
            // Arrange
            IWeapon weapon = Mock.Of<IWeapon>();

            var mockAttackBonusCalculator = new Mock<IAttackBonusCalculator>();
            var mockDamageBonusCalculator = new Mock<IDamageBonusCalculator>();
            var mockAttackBlock = new Mock<IAttackBlock>();
            mockAttackBlock.SetupGet(atk => atk.Weapon)
                           .Returns(weapon);
            mockAttackBlock.SetupGet(atk => atk.AttackBonus)
                           .Returns(mockAttackBonusCalculator.Object);
            mockAttackBlock.SetupGet(atk => atk.DamageBonus)
                           .Returns(mockDamageBonusCalculator.Object);
            var attackBlock = mockAttackBlock.Object;

            var mockCharacter = new Mock<ICreature>();
            mockCharacter.Setup(c => c.GetAttacks()).Returns(new IAttackBlock[] { attackBlock });
            var character = mockCharacter.Object;

            byte enhancementBonus = 3;

            // Act
            EnhancementEnchantment.ApplyTo(weapon, character, enhancementBonus);

            // Assert
            mockAttackBonusCalculator.Verify(atkb => atkb.AddModifier(It.Is<Func<sbyte>>(mod => enhancementBonus == mod())), Times.Once);
            mockDamageBonusCalculator.Verify(dmgb => dmgb.AddModifier(It.Is<Func<sbyte>>(mod => enhancementBonus == mod())), Times.Once);
        }
        #endregion
    }
}