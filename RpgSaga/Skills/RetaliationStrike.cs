namespace RpgSaga.Skills
{
    using RpgSaga.Heros;

    public class RetaliationStrike : Skill
    {
        public RetaliationStrike(ILogger logger, IHero hero)
            : base(logger, hero)
        {
        }

        public override void Use(IHero hero)
        {
            int damage = (int)(Owner.Damage * 1.3);
            Logger.Log($"{Owner.Name} использует удар возмездия и наносит урон {damage} противнику {hero.Name}");
            hero.DealDamage(damage);
        }
    }
}
