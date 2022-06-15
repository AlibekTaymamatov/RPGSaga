namespace RpgSagaLib.Heros
{
    using RpgSagaLib.Skills;

    public class Knight : Hero
    {
        public Knight(int healthPoints, int strength, string name, int armor, int intelligence, int speed, ILogger logger)
            : base(healthPoints, strength, $"(Рыцарь) {name}", armor, intelligence, speed, logger)
        {
            Status.Skills.Add(new Hit(logger, this));
            Status.Skills.Add(new RetaliationStrike(logger, this));
        }
    }
}
