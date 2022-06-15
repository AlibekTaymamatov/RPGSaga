namespace RpgSagaLib.Skills
{
    using RpgSagaLib.Effects;
    using RpgSagaLib.Heros;

    public class FascinationSkill : Skill
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
