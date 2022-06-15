namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Heros;

    public class FascinationSkill : Skill // клас котрый навешивате на протвника завражение т
    {
        public FascinationSkill(ILogger logger, IHero hero)
            : base(logger, hero)
        {
        }

        public override void Use(IHero hero)
        {
            Logger.Log($"{Owner.Name} накладывает заворожение на {hero.Name}");
            hero.UseEffect(new FascinationEffect(Logger));
        }
    }
}
