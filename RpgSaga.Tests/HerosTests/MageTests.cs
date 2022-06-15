namespace RpgSagaLib.Tests.HerosTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using Xunit;

    public class MageTests
    {
        [Fact]
        public void NameGenerationTest()
        {
            var logger = new Mock<ILogger>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            Assert.Equal(mage.Name, $"(Маг) {TestVariableHero.GetName()}");
        }

        [Fact]
        public void StepTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(mage);

            mage.EffectsExposureStep();
            mage.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{mage.Name} наносит урон {mage.StatusUnderEffects.Strength} противнику {mage.Name}",
                $"{mage.Name} накладывает заворожение на {mage.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void UseEffectTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            mage.UseEffect(new FascinationEffect(logger.Object));
            mage.EffectsExposureStep();
            mage.Step(battle.Object);

            string messages = $"{mage.Name} пропускает ход.";
            logger.Verify(l => l.Log(messages));
        }

        [Fact]
        public void ClearEffectsTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(mage);

            mage.UseEffect(new FascinationEffect(logger.Object));
            mage.ClearEffects();
            mage.EffectsExposureStep();
            mage.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{mage.Name} наносит урон {mage.StatusUnderEffects.Strength} противнику {mage.Name}",
                $"{mage.Name} накладывает заворожение на {mage.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void DealDamageIsLiveTest()
        {
            var logger = new Mock<ILogger>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            Assert.True(mage.IsLive());
            mage.DealDamage(mage.StatusUnderEffects.HealthPoints);
            Assert.False(mage.IsLive());
        }

        [Fact]
        public void RestartHeroTest()
        {
            var logger = new Mock<ILogger>();

            Mage mage = TestVariableHero.GetMage(logger.Object);

            mage.DealDamage(mage.StatusUnderEffects.HealthPoints);
            mage.RestartHero();
            Assert.True(mage.IsLive());
        }
    }
}
