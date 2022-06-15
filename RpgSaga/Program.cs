namespace CourseApp
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            RpgSagaLib.Game game = new RpgSagaLib.Game();

            int countHero;

            Console.WriteLine("Введите кол-во игроков или путь к файлу");
            while (true)
            {
                try
                {
                    string countHeroStr = Console.ReadLine();

                    if (!string.IsNullOrEmpty(countHeroStr) && int.TryParse(countHeroStr, out countHero))
                    {
                        game.RunGame(countHero);
                    }
                    else
                    {
                        game.RunGame(countHeroStr);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
