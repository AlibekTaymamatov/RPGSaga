namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Heros;

    public class FireArrows : Skill
    {
        private bool useSkill = false;

        public FireArrows(ILogger logger, IHero hero)
            : base(logger, hero)
        {
        }

        public override void Use(IHero hero)
        {
            useSkill = true;
            Logger.Log($"{Owner.Name} стреляет огненными стрелами в {hero.Name}");
            hero.UseEffect(new FireEffect(Logger));
        }

        public override bool IsReady()
        {
            return !useSkill;
        }

        public override void Restart()
        {
            useSkill = false;
        }
    }
}
