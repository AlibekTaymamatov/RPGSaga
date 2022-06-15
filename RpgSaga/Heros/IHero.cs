namespace RpgSaga.Heros
{
    using RpgSaga.Effects;

    public interface IHero
    {
        string Name { get; }

        int Damage { get; }

        void DealDamage(int damage);

        void UseEffect(Effect effect);

        void Hod(IBattle battle);

        void HodEffects();

        bool IsLive();

        void ClearEffects();

        void RestartHero();

        void RestartSkils();
    }
}
