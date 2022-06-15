namespace RpgSaga.Heros
{
    using RpgSaga.Skills;

    public class Knight : Hero
    {
        public Knight(int healthPoints, int damage, string name, ILogger logger)
            : base(healthPoints, damage, $"(Рыцарь) {name}", logger)
        {
            Skills.Add(new Hit(logger, this));
            Skills.Add(new RetaliationStrike(logger, this));
        }
    }
}
