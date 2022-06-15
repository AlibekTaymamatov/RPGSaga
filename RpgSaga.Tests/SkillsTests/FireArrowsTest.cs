namespace RpgSagaLib.Tests.SkillsTests
{
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;
    using RpgSagaLib.Skills;
    using Xunit;

    public class FireArrowsTest
    {
        [Fact]
        public void UseTest()
        {
            var logger = new Mock<ILogger>();
            var hero = new Mock<IHero>();

            string name = TestVariableHero.GetName();
            hero.SetupGet(h => h.Name).Returns(name);

            FireArrows fireArrows = new FireArrows(logger.Object, hero.Object);
            fireArrows.Use(hero.Object);

            logger.Verify(l => l.Log($"{name} стреляет огненными стрелами в {name}"));
            hero.Verify(h => h.UseEffect(It.IsAny<FireEffect>()));
        }

        [Fact]
        public void IsReadyTest()
        {
            var logger = new Mock<ILogger>();
            string name = TestVariableHero.GetName();
            Hero hero = TestVariableHero.GetMage(logger.Object);

            FireArrows fireArrows = new FireArrows(logger.Object, hero);
            fireArrows.Use(hero);

            Assert.True(!fireArrows.IsReady());
        }

        [Fact]
        public void RestartTest()
        {
            var logger = new Mock<ILogger>();
            string name = TestVariableHero.GetName();
            Hero hero = TestVariableHero.GetMage(logger.Object);

            FireArrows fireArrows = new FireArrows(logger.Object, hero);
            fireArrows.Use(hero);
            fireArrows.Restart();

            Assert.True(fireArrows.IsReady());
        }
    }
}
