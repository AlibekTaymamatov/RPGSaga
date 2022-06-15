namespace RpgSagaLib
{
    using RpgSagaLib.Heros;

    public interface IBattle
    {
        IHero GetOpponent();

        IHero StartBattle();
    }
}
