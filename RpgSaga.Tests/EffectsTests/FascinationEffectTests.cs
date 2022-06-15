namespace RpgSagaLib.Tests.EffectsTests
{
    using System.Collections.Generic;
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using RpgSagaLib.Skills;
    using Xunit;

    public class FascinationEffectTests
    {
        [Fact]
        public void IsEndedTest()
        {
            var logger = new Mock<ILogger>();

            FascinationEffect effect = new FascinationEffect(logger.Object);

            Assert.False(effect.IsEnded());
        }

        [Fact]
        public void UseTest()
        {
            var logger = new Mock<ILogger>();
            var hero = new Mock<IHero>();

            Status status = new Status();
            status.Skills = new List<Skill>();

            hero.Setup(h => h.StatusUnderEffects).Returns(status);

            FascinationEffect effect = new FascinationEffect(logger.Object);

            effect.Use(hero.Object);

            Assert.True(effect.IsEnded());
        }
    }
}
