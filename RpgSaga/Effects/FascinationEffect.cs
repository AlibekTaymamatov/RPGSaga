namespace RpgSaga.Effects
{
    using RpgSaga.Heros;
    using RpgSaga.Skills;

    public class FascinationEffect : Effect // класс заворажения
    {
        private int time = 1;

        public FascinationEffect(ILogger logger)
            : base(logger)
        {
        }

        public override bool IsEnded()
        {
            return time <= 0;
        }

        public override void Use(IHero hero)
        {
            time--;
        }

        public override bool SkillUse(Skill skill) // запрещать использовать скилы
        {
            return false;
        }
    }
}
