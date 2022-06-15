namespace RpgSaga.Heros
{
    using RpgSaga.Skills;

    public class Archer : Hero
    {
        public Archer(int healthPoints, int damage, string name, ILogger logger)
            : base(healthPoints, damage, $"(Лучник) {name}", logger)
        {
            Skills.Add(new Hit(logger, this));
            Skills.Add(new FireArrows(logger, this));
        }
}
}
