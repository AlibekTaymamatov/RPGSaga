namespace RpgSagaLib.InputOutput
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using RpgSagaLib.Heros;

    public class HeroCollectorFromFile : LoggerConnect
    {
        public HeroCollectorFromFile(ILogger logger)
            : base(logger)
        {
        }

        public List<IHero> GetHerosJson(string json)
        {
            HeroFileEntity[] restoredPerson = JsonSerializer.Deserialize<HeroFileEntity[]>(json);
            FactoryHeroes factoryHeroes = new FactoryHeroes(Logger);
            List<IHero> heros = restoredPerson.Select(i => factoryHeroes.CreateHero(i.Class, i.Name, i.HealthPoints, i.Strength, i.Armor, i.Intelligence, i.Speed)).ToList();
            return heros;
        }
    }
}
