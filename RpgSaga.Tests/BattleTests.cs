namespace RpgSagaLib.Tests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Heros;
    using Xunit;

    public class BattleTests
    {
        [Fact]
        public void Hero1WinWithoutMovesTest()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();

            string name1 = TestVariableHero.GetName(1);
            hero1.SetupGet(h => h.Name).Returns(name1);
            hero1.Setup(h => h.IsLive()).Returns(true);

            string name2 = TestVariableHero.GetName(2);
            hero2.SetupGet(h => h.Name).Returns(name2);
            hero2.Setup(h => h.IsLive()).Returns(false);

            Battle battle = new Battle(hero1.Object, hero2.Object, logger.Object);
            Assert.Equal(battle.StartBattle(), hero1.Object);

            logger.Verify(l => l.Log($"{name1} победил!"));

            hero1.Verify(h => h.EffectsExposureStep(), Times.Never());
            hero1.Verify(h => h.Step(battle), Times.Never());
            hero2.Verify(h => h.EffectsExposureStep(), Times.Never());
            hero2.Verify(h => h.Step(battle), Times.Never());
        }

        [Fact]
        public void Hero2WinWithoutMovesTest()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();

            string name1 = TestVariableHero.GetName(1);
            hero1.SetupGet(h => h.Name).Returns(name1);
            hero1.Setup(h => h.IsLive()).Returns(false);

            string name2 = TestVariableHero.GetName(2);
            hero2.SetupGet(h => h.Name).Returns(name2);
            hero2.Setup(h => h.IsLive()).Returns(true);

            Battle battle = new Battle(hero1.Object, hero2.Object, logger.Object);
            Assert.Equal(battle.StartBattle(), hero2.Object);

            logger.Verify(l => l.Log($"{name2} победил!"));

            hero1.Verify(h => h.EffectsExposureStep(), Times.Never());
            hero1.Verify(h => h.Step(battle), Times.Never());
            hero2.Verify(h => h.EffectsExposureStep(), Times.Never());
            hero2.Verify(h => h.Step(battle), Times.Never());
        }

        [Fact]
        public void Hero1WinTest()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();

            string name1 = TestVariableHero.GetName(1);
            hero1.SetupGet(h => h.Name).Returns(name1);
            hero1.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(true).Returns(true);

            string name2 = TestVariableHero.GetName(2);
            hero2.SetupGet(h => h.Name).Returns(name2);
            hero2.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(false).Returns(false);

            Battle battle = new Battle(hero1.Object, hero2.Object, logger.Object);
            Assert.Equal(battle.StartBattle(), hero1.Object);

            logger.Verify(l => l.Log($"{name1} победил!"));

            hero1.Verify(h => h.EffectsExposureStep(), Times.Once());
            hero1.Verify(h => h.Step(battle), Times.Once());
            hero2.Verify(h => h.EffectsExposureStep(), Times.Never());
            hero2.Verify(h => h.Step(battle), Times.Never());
        }

        [Fact]
        public void Hero2WinTest()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();

            string name1 = TestVariableHero.GetName(1);
            hero1.SetupGet(h => h.Name).Returns(name1);
            hero1.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(true).Returns(true).Returns(false).Returns(false);

            string name2 = TestVariableHero.GetName(2);
            hero2.SetupGet(h => h.Name).Returns(name2);
            hero2.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(true).Returns(true).Returns(true).Returns(true);

            Battle battle = new Battle(hero1.Object, hero2.Object, logger.Object);
            Assert.Equal(battle.StartBattle(), hero2.Object);

            logger.Verify(l => l.Log($"{name2} победил!"));

            hero1.Verify(h => h.EffectsExposureStep(), Times.Once());
            hero1.Verify(h => h.Step(battle), Times.Once());
            hero2.Verify(h => h.EffectsExposureStep(), Times.Once());
            hero2.Verify(h => h.Step(battle), Times.Once());
        }

        [Fact]
        public void GetOpponentTest()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();

            string name1 = TestVariableHero.GetName(1);
            hero1.SetupGet(h => h.Name).Returns(name1);
            hero1.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(true).Returns(true);

            string name2 = TestVariableHero.GetName(2);
            hero2.SetupGet(h => h.Name).Returns(name2);
            hero2.SetupSequence(h => h.IsLive()).Returns(true).Returns(true).Returns(false).Returns(false);

            Battle battle = new Battle(hero1.Object, hero2.Object, logger.Object);
            Assert.Equal(battle.GetOpponent(), hero2.Object);
            battle.StartBattle();
            Assert.Equal(battle.GetOpponent(), hero1.Object);
        }
    }
}
