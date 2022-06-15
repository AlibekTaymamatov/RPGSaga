namespace RpgSagaLib.Tests.HerosTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using Xunit;

    public class KnightTests
    {
        [Fact]
        public void NameGenerationTest()
        {
            var logger = new Mock<ILogger>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            Assert.Equal(knight.Name, $"(Рыцарь) {TestVariableHero.GetName()}");
        }

        [Fact]
        public void StepTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(knight);

            knight.EffectsExposureStep();
            knight.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{knight.Name} наносит урон {knight.StatusUnderEffects.Strength} противнику {knight.Name}",
                $"{knight.Name} использует удар возмездия и наносит урон {knight.StatusUnderEffects.Strength * 1.3} противнику {knight.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void UseEffectTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            knight.UseEffect(new FascinationEffect(logger.Object));
            knight.EffectsExposureStep();
            knight.Step(battle.Object);

            string messages = $"{knight.Name} пропускает ход.";
            logger.Verify(l => l.Log(messages));
        }

        [Fact]
        public void ClearEffectsTest()
        {
            var logger = new Mock<ILogger>();
            var battle = new Mock<IBattle>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            battle.Setup(b => b.GetOpponent()).Returns(knight);

            knight.UseEffect(new FascinationEffect(logger.Object));
            knight.ClearEffects();
            knight.EffectsExposureStep();
            knight.Step(battle.Object);

            string[] messages = new string[]
            {
                $"{knight.Name} наносит урон {knight.StatusUnderEffects.Strength} противнику {knight.Name}",
                $"{knight.Name} использует удар возмездия и наносит урон {knight.StatusUnderEffects.Strength * 1.3} противнику {knight.Name}",
            };
            logger.Verify(l => l.Log(It.IsIn(messages)));
        }

        [Fact]
        public void DealDamageIsLiveTest()
        {
            var logger = new Mock<ILogger>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            Assert.True(knight.IsLive());
            knight.DealDamage(knight.StatusUnderEffects.HealthPoints);
            Assert.False(knight.IsLive());
        }

        [Fact]
        public void RestartHeroTest()
        {
            var logger = new Mock<ILogger>();

            Knight knight = TestVariableHero.GetKnight(logger.Object);

            knight.DealDamage(knight.StatusUnderEffects.HealthPoints);
            knight.RestartHero();
            Assert.True(knight.IsLive());
        }
    }
}