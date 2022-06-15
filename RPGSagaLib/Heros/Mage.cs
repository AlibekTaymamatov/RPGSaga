namespace RpgSagaLib.Heros
{
    using RpgSagaLib.Skills;

    public class Mage : Hero
    {
        public Mage(int healthPoints, int strength, string name, int armor, int intelligence, int speed, ILogger logger)
            : base(healthPoints, strength, $"(Маг) {name}", armor, intelligence, speed, logger)
        {
            Status.Skills.Add(new Hit(logger, this));
            Status.Skills.Add(new FascinationSkill(logger, this));
        }
    }
}
