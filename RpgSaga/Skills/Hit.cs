namespace RpgSaga.Skills
{
    using RpgSaga.Heros;

    public class Hit : Skill // бьет противнка взавитмости от урона владельцы
    {
        public Hit(ILogger logger, IHero hero)
            : base(logger, hero)
        {
        }

        public override void Use(IHero hero)
        {
            Logger.Log($"{Owner.Name} наносит урон {Owner.Damage} противнику {hero.Name}");
            hero.DealDamage(Owner.Damage);
        }
    }
}
