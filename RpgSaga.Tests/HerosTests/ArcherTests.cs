namespace RpgSagaLib.Tests.HerosTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using Xunit;

    public class ArcherTests
    {
        [Fact]
        public void NameGenerationTest()
        {
            var logger = new Mock<ILogger>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            Assert.Equal(archer.Name, $"(Лучник) {TestVariableHero.GetName()}");
        }

        [Fact]
        public void StepTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(archer);

            archer.EffectsExposureStep();
            archer.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{archer.Name} наносит урон {archer.StatusUnderEffects.Strength} противнику {archer.Name}",
                $"{archer.Name} стреляет огненными стрелами в {archer.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void UseEffectTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            archer.UseEffect(new FascinationEffect(logger.Object));
            archer.EffectsExposureStep();
            archer.Step(battle.Object);

            string messages = $"{archer.Name} пропускает ход.";
            logger.Verify(l => l.Log(messages));
        }

        [Fact]
        public void ClearEffectsTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(archer);

            archer.UseEffect(new FascinationEffect(logger.Object));
            archer.ClearEffects();
            archer.EffectsExposureStep();
            archer.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{archer.Name} наносит урон {archer.StatusUnderEffects.Strength} противнику {archer.Name}",
                $"{archer.Name} стреляет огненными стрелами в {archer.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void IsLiveTest()
        {
            var logger = new Mock<ILogger>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            Assert.True(archer.IsLive());
            archer.DealDamage(TestVariableHero.GetHealthPoints());
            Assert.False(archer.IsLive());
        }

        [Fact]
        public void RestartHeroTest()
        {
            var logger = new Mock<ILogger>();

            Archer archer = TestVariableHero.GetArcher(logger.Object);

            archer.DealDamage(TestVariableHero.GetHealthPoints());
            archer.RestartHero();
            Assert.True(archer.IsLive());
        }
    }
}
