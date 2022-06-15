namespace RpgSagaLib.Heros
{
    using System.Collections.Generic;
    using RpgSagaLib.Skills;

    public class Status
    {
        public Status()
        {
        }

        public Status(Status status)
        {
            HealthPoints = status.HealthPoints;
            MaxHealthPoints = status.MaxHealthPoints;
            Armor = status.Armor;
            Strength = status.Strength;
            Intelligence = status.Intelligence;
            Speed = status.Speed;
            Skills = new List<Skill>(status.Skills);
        }

        public int HealthPoints { get; set; }

        public int MaxHealthPoints { get; set; }

        public int Armor { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Speed { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
