using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Attacks;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Attacks
{
    public class AttackBlockTest
    {
        #region Constructor
        [Fact]
        public void Constructor_NullStrength_Throws()
        {
            // Arrange
            IAbilityScore strength = null;
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;
            IWeapon weapon = Mock.Of<IWeapon>();

            // Act
            Action constructor = () => new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullDexterity_Throws()
        {
            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = null;
            Func<byte> proficiencyBonus = () => 2;
            IWeapon weapon = Mock.Of<IWeapon>();

            // Act
            Action constructor = () => new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullProficiency_Throws()
        {
            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = null;
            IWeapon weapon = Mock.Of<IWeapon>();

            // Act
            Action constructor = () => new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void Constructor_NullWeapon_Throws()
        {
            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;
            IWeapon weapon = null;

            // Act
            Action constructor = () => new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;
            IWeapon weapon = Mock.Of<IWeapon>();

            // Act
            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Assert
            Assert.IsType<AttackBonusCalculator>(attackBlock.AttackBonus);
            Assert.IsType<DamageBonusCalculator>(attackBlock.DamageBonus);
            Assert.Same(weapon, attackBlock.Weapon);
        }
        #endregion

        #region GetAbilityScore
        [Fact]
        public void GetAbilityScore_DefaultCase()
        {
            // By default, weapons should use Strength.
            // This includes weapons with no special properties.

            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[0]); // No special properties
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(strength, result);
        }


        [Fact]
        public void GetAbilityScore_Thrown()
        {
            // Thrown weapons (which lack Finesse) should use strength.

            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Thrown });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(strength, result);
        }


        [Fact]
        public void GetAbilityScore_Range()
        {
            // Ranged weapons should use Dexterity.

            // Arrange
            IAbilityScore strength = Mock.Of<IAbilityScore>();
            IAbilityScore dexterity = Mock.Of<IAbilityScore>();
            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Range });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(dexterity, result);
        }


        [Fact]
        public void GetAbilityScore_Finesse_StrengthHigher()
        {
            // Finesse weapons should use strength if strength is higher than dexterity.

            // Arrange
            byte  strScore = 18;
            sbyte strMod   =  4;
            byte  dexScore = 10;
            sbyte dexMod   =  0;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Finesse });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(strength, result);
        }


        [Fact]
        public void GetAbilityScore_Finesse_DexterityHigher()
        {
            // Finesse weapons should use dexterity if dexterity is higher than strength.

            // Arrange
            byte  strScore = 10;
            sbyte strMod   =  0;
            byte  dexScore = 18;
            sbyte dexMod   =  4;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Finesse });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(dexterity, result);
        }


        [Fact]
        public void GetAbilityScore_Nonfinesse_WithCandidate_StrengthHighest()
        {
            // If the default ability score is higher than a candidate ability score,
            // the default ability score should be used.

            // Arrange
            byte  strScore = 18;
            sbyte strMod   =  4;
            byte  dexScore = 12;
            sbyte dexMod   =  1;
            byte  chaScore = 10;
            sbyte chaMod   =  0;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            var mockCharisma = new Mock<IAbilityScore>();
            mockCharisma.SetupGet(cha => cha.Score)
                         .Returns(chaScore);
            mockCharisma.SetupGet(cha => cha.Modifer)
                         .Returns(chaMod);
            IAbilityScore charisma = mockCharisma.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[0]);
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);
            attackBlock.AddCandidateAbilityScore(charisma);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(strength, result);
        }


        [Fact]
        public void GetAbilityScore_Nonfinesse_WithCandidate_CharismaHigher()
        {
            // If the default ability score is higher than a candidate ability score,
            // the default ability score should be used.

            // Arrange
            byte  strScore = 12;
            sbyte strMod   =  1;
            byte  dexScore = 10;
            sbyte dexMod   =  0;
            byte  chaScore = 18;
            sbyte chaMod   =  4;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            var mockCharisma = new Mock<IAbilityScore>();
            mockCharisma.SetupGet(cha => cha.Score)
                         .Returns(chaScore);
            mockCharisma.SetupGet(cha => cha.Modifer)
                         .Returns(chaMod);
            IAbilityScore charisma = mockCharisma.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[0]);
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);
            attackBlock.AddCandidateAbilityScore(charisma);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(charisma, result);
        }


        [Fact]
        public void GetAbilityScore_Finesse_WithCandidate_DexterityHighest()
        {
            // If the default ability score is higher than a candidate ability score,
            // the default ability score should be used.

            // Arrange
            byte  strScore = 12;
            sbyte strMod   =  1;
            byte  dexScore = 18;
            sbyte dexMod   =  4;
            byte  chaScore = 10;
            sbyte chaMod   =  0;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            var mockCharisma = new Mock<IAbilityScore>();
            mockCharisma.SetupGet(cha => cha.Score)
                         .Returns(chaScore);
            mockCharisma.SetupGet(cha => cha.Modifer)
                         .Returns(chaMod);
            IAbilityScore charisma = mockCharisma.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Finesse });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);
            attackBlock.AddCandidateAbilityScore(charisma);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(dexterity, result);
        }


        [Fact]
        public void GetAbilityScore_Finesse_WithCandidate_CharismaHighest()
        {
            // If the default ability score is higher than a candidate ability score,
            // the default ability score should be used.

            // Arrange
            byte  strScore = 10;
            sbyte strMod   =  0;
            byte  dexScore = 12;
            sbyte dexMod   =  1;
            byte  chaScore = 18;
            sbyte chaMod   =  4;

            var mockStrength = new Mock<IAbilityScore>();
            mockStrength.SetupGet(str => str.Score)
                        .Returns(strScore);
            mockStrength.SetupGet(str => str.Modifer)
                        .Returns(strMod);
            IAbilityScore strength = mockStrength.Object;

            var mockDexterity = new Mock<IAbilityScore>();
            mockDexterity.SetupGet(dex => dex.Score)
                         .Returns(dexScore);
            mockDexterity.SetupGet(dex => dex.Modifer)
                         .Returns(dexMod);
            IAbilityScore dexterity = mockDexterity.Object;

            var mockCharisma = new Mock<IAbilityScore>();
            mockCharisma.SetupGet(cha => cha.Score)
                         .Returns(chaScore);
            mockCharisma.SetupGet(cha => cha.Modifer)
                         .Returns(chaMod);
            IAbilityScore charisma = mockCharisma.Object;

            Func<byte> proficiencyBonus = () => 2;

            var mockWeapon = new Mock<IWeapon>();
            mockWeapon.Setup(w => w.GetProperties())
                      .Returns(new WeaponProperty[] { WeaponProperty.Finesse });
            var weapon = mockWeapon.Object;

            var attackBlock = new AttackBlock(strength, dexterity, proficiencyBonus, weapon);
            attackBlock.AddCandidateAbilityScore(charisma);

            // Act
            var result = attackBlock.GetKeyAbilityScore();

            // Assert
            Assert.Same(charisma, result);
        }
        #endregion
    }
}