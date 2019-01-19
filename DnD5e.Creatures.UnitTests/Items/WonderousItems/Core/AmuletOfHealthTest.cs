using System;
using DnD5e.Creatures.AbilityScores;
using DnD5e.Creatures.Items;
using DnD5e.Creatures.Items.WonderousItems.Core;
using Moq;
using Xunit;


namespace DnD5e.Creatures.UnitTests.Items.WonderousItems.Core
{
    public class AmuletOfHealthTest
    {
        [Fact]
        public void DefaultProperties()
        {
            // Arrange
            var item = new AmuletOfHealth();

            // Act

            // Assert
            Assert.Equal("Amulet of Health", item.Name);
            Assert.Equal(Rarity.Rare, item.Rarity);
            Assert.True(item.RequiresAtunement);
            Assert.Equal(0, item.Weight);
            Assert.Null(item.MarketValue);
        }


        [Fact]
        public void ApplyTo_NullArg_Throws()
        {
            // Arrange
            var item = new AmuletOfHealth();

            // Act
            Action applyTo = () => item.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(applyTo);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        public void ApplyTo_Under19Con_Applied(byte originalScore)
        {
            // Arrange
            var mockConstitution = new Mock<IAbilityScore>();
            mockConstitution.SetupGet(con => con.Score)
                            .Returns(originalScore);
            var mockAbilityScores = new Mock<IAbilityScoresSection>();
            mockAbilityScores.SetupGet(abScSec => abScSec.Constitution)
                             .Returns(mockConstitution.Object);
            var mockCreature = new Mock<ICreature>();
            mockCreature.SetupGet(c => c.AbilityScores)
                        .Returns(mockAbilityScores.Object);

            var item = new AmuletOfHealth();

            // Act
            item.ApplyTo(mockCreature.Object);

            // Assert
            mockConstitution.VerifySet(con => con.Score = It.Is<byte>(newScore => 19 == newScore), Times.Once);
        }


        [Theory]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(30)]
        public void ApplyTo_19PlusCon_NotApplied(byte originalScore)
        {
            // Arrange
            var mockConstitution = new Mock<IAbilityScore>();
            mockConstitution.SetupGet(con => con.Score)
                            .Returns(originalScore);
            var mockAbilityScores = new Mock<IAbilityScoresSection>();
            mockAbilityScores.SetupGet(abScSec => abScSec.Constitution)
                             .Returns(mockConstitution.Object);
            var mockCreature = new Mock<ICreature>();
            mockCreature.SetupGet(c => c.AbilityScores)
                        .Returns(mockAbilityScores.Object);

            var item = new AmuletOfHealth();

            // Act
            item.ApplyTo(mockCreature.Object);

            // Assert
            mockConstitution.VerifySet(con => con.Score = It.IsAny<byte>(), Times.Never);
        }
    }
}