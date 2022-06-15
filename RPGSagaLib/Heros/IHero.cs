namespace RpgSagaLib.Heros
{
    using RpgSagaLib.Effects;

    public interface IHero
    {
        Status StatusUnderEffects { get; }

        string Name { get; }

        void UseEffect(Effect effect);

        void DealDamage(int damage);

        void Step(IBattle battle);

        void EffectsExposureStep();

        bool IsLive();

        void ClearEffects();

        void RestartHero();

        void RestartSkils();
    }
}
