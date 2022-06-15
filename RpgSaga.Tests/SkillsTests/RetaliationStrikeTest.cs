namespace RpgSagaLib.Tests.SkillsTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Heros;
    using RpgSagaLib.Skills;
    using Xunit;

    public class RetaliationStrikeTest
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

            RetaliationStrike retaliationStrike = new RetaliationStrike(logger.Object, hero.Object);
            retaliationStrike.Use(hero.Object);

            logger.Verify(lw => lw.Log($"{name} использует удар возмездия и наносит урон {strength * 1.3} противнику {name}"));
            hero.Verify(h => h.DealDamage((int)(strength * 1.3)));
        }
    }
}
