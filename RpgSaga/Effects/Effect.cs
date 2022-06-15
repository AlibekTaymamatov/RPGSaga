namespace RpgSaga.Effects
{
    using RpgSaga.Heros;
    using RpgSaga.Skills;

    public abstract class Effect : LoggerConnect // эффекты
    {
        public Effect(ILogger logger)
            : base(logger)
        {
        }

        public abstract void Use(IHero hero); // использовать эффект

        public abstract bool IsEnded(); // проверять что эффект закончился

        public virtual bool SkillUse(Skill skill) // проверка что этот эффект позволяет использовать данный скилл
        {
            return true;
        }
    }
}