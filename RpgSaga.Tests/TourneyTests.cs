namespace RpgSagaLib.Tests
{
    using System.Collections.Generic;
    using Moq;
    using RpgSagaLib;
    using RpgSagaLib.Heros;
    using Xunit;

    public class TourneyTests
    {
        [Fact]
        public void CountHero0_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            int countHero = 0;

            Tourney tourney = new Tourney(logger.Object, countHero);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }

        [Fact]
        public void CountHero1_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            int countHero = 1;

            Tourney tourney = new Tourney(logger.Object, countHero);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }

        [Fact]
        public void CountHero2_Success_Test()
        {
            var logger = new Mock<ILogger>();
            int countHero = 2;

            Tourney tourney = new Tourney(logger.Object, countHero);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"), Times.Never);
        }

        [Fact]
        public void CountHero3_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            int countHero = 3;

            Tourney tourney = new Tourney(logger.Object, countHero);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }

        [Fact]
        public void ListCount0_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            List<IHero> heros = new List<IHero>();

            Tourney tourney = new Tourney(logger.Object, heros);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }

        [Fact]
        public void ListCount1_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();

            List<IHero> heros = new List<IHero>();
            heros.Add(hero1.Object);

            Tourney tourney = new Tourney(logger.Object, heros);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }

        [Fact]
        public void ListCount2_Success_Test()
        {
            var logger = new Mock<ILogger>();

            string name1 = TestVariableHero.GetName(1);
            var hero1 = new Mock<IHero>();
            hero1.Setup(h1 => h1.IsLive()).Returns(true);
            hero1.SetupGet(h1 => h1.Name).Returns(name1);

            string name2 = TestVariableHero.GetName(2);
            var hero2 = new Mock<IHero>();
            hero2.Setup(h2 => h2.IsLive()).Returns(false);
            hero2.SetupGet(h2 => h2.Name).Returns(name2);

            List<IHero> heros = new List<IHero>();
            heros.Add(hero1.Object);
            heros.Add(hero2.Object);

            Tourney tourney = new Tourney(logger.Object, heros);
            tourney.Start();

            logger.Verify(l => l.Log($"Единственный выживший {name1}"));
            logger.Verify(l => l.Log("Неверный ввод"), Times.Never);
        }

        [Fact]
        public void ListCount3_Fail_Test()
        {
            var logger = new Mock<ILogger>();
            var hero1 = new Mock<IHero>();
            var hero2 = new Mock<IHero>();
            var hero3 = new Mock<IHero>();

            List<IHero> heros = new List<IHero>();
            heros.Add(hero1.Object);
            heros.Add(hero2.Object);
            heros.Add(hero3.Object);

            Tourney tourney = new Tourney(logger.Object, heros);
            tourney.Start();

            logger.Verify(l => l.Log("Неверный ввод"));
        }
    }
}
