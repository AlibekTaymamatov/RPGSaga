namespace RpgSagaLib.Skills
{
    using RpgSagaLib.Heros;

    public class Hit : Skill
    {
        public Hit(ILogger logger, IHero hero)
            : base(logger, hero)
        {
        }

        public override void Use(IHero hero)
        {
            int damage = Owner.StatusUnderEffects.Strength;
            Logger.Log($"{Owner.Name} наносит урон {damage} противнику {hero.Name}");
            hero.DealDamage(damage);
        }
    }
}
