namespace RpgSagaLib.Tests.SkillsTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Heros;
    using RpgSagaLib.Skills;
    using Xunit;

    public class HitTest
    {
        [Fact]
        public void UseTest()
        {
            var logger = new Mock<ILogger>();
            var hero = new Mock<IHero>();

            string name = TestVariableHero.GetName();
            int strength = TestVariableHero.GetStrength();
            Status status = new Status();
            status.Strength = strength;

            hero.SetupGet(h => h.Name).Returns(name);
            hero.SetupGet(h => h.StatusUnderEffects).Returns(status);

            Hit hit = new Hit(logger.Object, hero.Object);
            hit.Use(hero.Object);

            logger.Verify(lw => lw.Log($"{name} наносит урон {strength} противнику {name}"));
            hero.Verify(h => h.DealDamage(strength));
        }
    }
}
