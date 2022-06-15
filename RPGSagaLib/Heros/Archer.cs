namespace RpgSagaLib.Heros
{
    using RpgSagaLib.Skills;

    public class Archer : Hero
    {
        public Archer(int healthPoints, int strength, string name, int armor, int intelligence, int speed, ILogger logger)
            : base(healthPoints, strength, $"(Лучник) {name}", armor, intelligence, speed, logger)
        {
            Status.Skills.Add(new Hit(logger, this));
            Status.Skills.Add(new FireArrows(logger, this));
        }
}
}
