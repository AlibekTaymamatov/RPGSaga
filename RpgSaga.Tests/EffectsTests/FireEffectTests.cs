namespace RpgSagaLib.Tests.EffectsTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using Xunit;

    public class FireEffectTests
    {
        [Fact]
        public void IsEndedTest()
        {
            var logger = new Mock<ILogger>();

            FireEffect effect = new FireEffect(0, logger.Object);

            Assert.False(effect.IsEnded());
        }

        [Fact]
        public void UseTest()
        {
            var logger = new Mock<ILogger>();
            var hero = new Mock<IHero>();

            int damage = 2;
            string name = TestVariableHero.GetName();
            Status status = new Status();
            status.HealthPoints = TestVariableHero.GetHealthPoints();
            hero.SetupGet(h => h.Name).Returns(name);
            hero.SetupGet(h => h.StatusUnderEffects).Returns(status);

            FireEffect effect = new FireEffect(damage, logger.Object);

            effect.Use(hero.Object);

            logger.Verify(l => l.Log($"{name} горит и получает урон {damage}"));
            Assert.Equal(status.HealthPoints, TestVariableHero.GetHealthPoints() - damage);
        }
    }
}
