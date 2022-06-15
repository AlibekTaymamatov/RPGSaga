namespace RpgSaga
{
    public class Game
    {
        public Game()
        {
        }

        public void Start(int countHero)
        {
            Logger logger = new Logger();
            Tourney tourney = new Tourney(logger, countHero);
            tourney.Start();
        }
    }
}
