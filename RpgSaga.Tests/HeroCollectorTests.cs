namespace RpgSagaLib.Tests
{
    using System.Collections.Generic;
    using RpgSagaLib;
    using RpgSagaLib.Heros;
    using RpgSagaLib.InputOutput;
    using Xunit;

    public class HeroCollectorTests
    {
        [Fact]
        public void MageTest()
        {
            string name = TestVariableHero.GetName();
            int healthPoints = TestVariableHero.GetHealthPoints();
            int strength = TestVariableHero.GetStrength();
            int armor = TestVariableHero.GetArmor();
            int intelligence = TestVariableHero.GetIntelligence();
            int speed = TestVariableHero.GetSpeed();

            string line = $"[{{\"name\":\"{name}\",\"class\":\"Mage\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}]";

            ILogger logger = new Logger();
            HeroCollectorFromFile heroCollector = new HeroCollectorFromFile(logger);

            List<IHero> heros = heroCollector.GetHerosJson(line);

            int count = 1;

            Assert.Equal(heros.Count, count);
            Assert.Equal(heros[0].Name, $"(Маг) {name}");
            Assert.Equal(heros[0].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[0].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[0].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[0].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[0].StatusUnderEffects.Intelligence, intelligence);
        }

        [Fact]
        public void ArcherTest()
        {
            string name = TestVariableHero.GetName();
            int healthPoints = TestVariableHero.GetHealthPoints();
            int strength = TestVariableHero.GetStrength();
            int armor = TestVariableHero.GetArmor();
            int intelligence = TestVariableHero.GetIntelligence();
            int speed = TestVariableHero.GetSpeed();

            string line = $"[{{\"name\":\"{name}\",\"class\":\"Archer\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}]";

            ILogger logger = new Logger();
            HeroCollectorFromFile heroCollector = new HeroCollectorFromFile(logger);

            List<IHero> heros = heroCollector.GetHerosJson(line);

            int count = 1;

            Assert.Equal(heros.Count, count);
            Assert.Equal(heros[0].Name, $"(Лучник) {name}");
            Assert.Equal(heros[0].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[0].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[0].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[0].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[0].StatusUnderEffects.Intelligence, intelligence);
        }

        [Fact]
        public void KnightTest()
        {
            string name = TestVariableHero.GetName();
            int healthPoints = TestVariableHero.GetHealthPoints();
            int strength = TestVariableHero.GetStrength();
            int armor = TestVariableHero.GetArmor();
            int intelligence = TestVariableHero.GetIntelligence();
            int speed = TestVariableHero.GetSpeed();

            string line = $"[{{\"name\":\"{name}\",\"class\":\"Knight\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}]";

            ILogger logger = new Logger();
            HeroCollectorFromFile heroCollector = new HeroCollectorFromFile(logger);

            List<IHero> heros = heroCollector.GetHerosJson(line);

            int count = 1;

            Assert.Equal(heros.Count, count);
            Assert.Equal(heros[0].Name, $"(Рыцарь) {name}");
            Assert.Equal(heros[0].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[0].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[0].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[0].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[0].StatusUnderEffects.Intelligence, intelligence);
        }

        [Fact]
        public void ComprehensiveTest()
        {
            string name = TestVariableHero.GetName();
            int healthPoints = TestVariableHero.GetHealthPoints();
            int strength = TestVariableHero.GetStrength();
            int armor = TestVariableHero.GetArmor();
            int intelligence = TestVariableHero.GetIntelligence();
            int speed = TestVariableHero.GetSpeed();

            string line = $"[{{\"name\":\"{name}\",\"class\":\"Archer\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}," +
                $"{{\"name\":\"{name}\",\"class\":\"Mage\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}," +
                $"{{\"name\":\"{name}\",\"class\":\"Knight\",\"health_points\":{healthPoints},\"armor\":{armor},\"strength\":{strength},\"intelligence\":{intelligence},\"speed\":{speed}}}]";

            ILogger logger = new Logger();
            HeroCollectorFromFile heroCollector = new HeroCollectorFromFile(logger);

            List<IHero> heros = heroCollector.GetHerosJson(line);

            int count = 3;

            Assert.Equal(heros.Count, count);

            Assert.Equal(heros[0].Name, $"(Лучник) {name}");
            Assert.Equal(heros[0].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[0].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[0].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[0].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[0].StatusUnderEffects.Intelligence, intelligence);

            Assert.Equal(heros[1].Name, $"(Маг) {name}");
            Assert.Equal(heros[1].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[1].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[1].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[1].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[1].StatusUnderEffects.Intelligence, intelligence);

            Assert.Equal(heros[2].Name, $"(Рыцарь) {name}");
            Assert.Equal(heros[2].StatusUnderEffects.HealthPoints, healthPoints);
            Assert.Equal(heros[2].StatusUnderEffects.Strength, strength);
            Assert.Equal(heros[2].StatusUnderEffects.Armor, armor);
            Assert.Equal(heros[2].StatusUnderEffects.Speed, speed);
            Assert.Equal(heros[2].StatusUnderEffects.Intelligence, intelligence);
        }
    }
}
