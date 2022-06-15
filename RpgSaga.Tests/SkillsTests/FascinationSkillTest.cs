namespace RpgSagaLib.Tests.SkillsTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using RpgSagaLib.Skills;
    using Xunit;

    public class FascinationSkillTest
    {
        [Fact]
        public void UseTest()
        {
            var logger = new Mock<ILogger>();
            var hero = new Mock<IHero>();

            string name = TestVariableHero.GetName();
            hero.SetupGet(h => h.Name).Returns(name);

            FascinationSkill fascinationSkill = new FascinationSkill(logger.Object, hero.Object);
            fascinationSkill.Use(hero.Object);

            logger.Verify(l => l.Log($"{name} накладывает заворожение на {name}"));
            hero.Verify(h => h.UseEffect(It.IsAny<FascinationEffect>()));
        }
    }
}
