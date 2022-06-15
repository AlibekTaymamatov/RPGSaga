namespace RpgSaga.Heros
{
    using RpgSaga.Skills;

    public class Mage : Hero
    {
        public Mage(int healthPoints, int damage, string name, ILogger logger)
            : base(healthPoints, damage, $"(Маг) {name}", logger)
        {
            Skills.Add(new Hit(logger, this));
            Skills.Add(new FascinationSkill(logger, this));
        }
    }
}
