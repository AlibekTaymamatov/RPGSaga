namespace RpgSagaLib.InputOutput
{
    using System;
    using System.Text.Json.Serialization;

    public class HeroFileEntity
    {
        private HeroType classHero;

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public HeroType Class
        {
            get
            {
                return classHero;
            }

            set
            {
                classHero = value;
            }
        }

        [JsonPropertyName("class")]
        public string ClassString
        {
            get
            {
                return Enum.GetName(typeof(HeroType), classHero);
            }

            set
            {
                classHero = (HeroType)Enum.Parse(typeof(HeroType), value);
            }
        }

        [JsonPropertyName("health_points")]
        public int HealthPoints { get; set; }

        [JsonPropertyName("armor")]
        public int Armor { get; set; }

        [JsonPropertyName("strength")]
        public int Strength { get; set; }

        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }
    }
}
