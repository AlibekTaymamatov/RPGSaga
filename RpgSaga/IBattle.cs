namespace RpgSaga
{
    using RpgSaga.Heros;

    public interface IBattle
    {
        IHero GetOpponent();

        IHero StartBattle();
    }
}
