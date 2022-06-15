namespace RpgSagaLib.Tests
{
    using RpgSagaLib.Heros;

    public static class TestVariableHero
    {
        public static string GetName() => "Test_Name";

        public static string GetName(int value) => $"Test_Name_{value}";

        public static int GetHealthPoints() => 10;

        public static int GetStrength() => 10;

        public static int GetArmor() => 10;

        public static int GetIntelligence() => 10;

        public static int GetSpeed() => 10;

        public static Archer GetArcher(ILogger logger) => new Archer(GetHealthPoints(), GetStrength(), GetName(), GetArmor(), GetIntelligence(), GetSpeed(), logger);

        public static Mage GetMage(ILogger logger) => new Mage(GetHealthPoints(), GetStrength(), GetName(), GetArmor(), GetIntelligence(), GetSpeed(), logger);

        public static Knight GetKnight(ILogger logger) => new Knight(GetHealthPoints(), GetStrength(), GetName(), GetArmor(), GetIntelligence(), GetSpeed(), logger);
    }
}
