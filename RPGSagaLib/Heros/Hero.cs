namespace RpgSagaLib.Heros
{
    using System;
    using System.Collections.Generic;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Skills;

    public abstract class Hero : LoggerConnect, IHero
    {
        private Random rnd = new Random();

        public Hero(int healthPoints, int strength, string name, int armor, int intelligence, int speed, ILogger logger)
            : base(logger)
        {
            Status = new Status();
            Name = name;
            Status.HealthPoints = healthPoints;
            Status.MaxHealthPoints = healthPoints;
            Status.Strength = strength;
            Status.Armor = armor;
            Status.Intelligence = intelligence;
            Status.Speed = speed;
            Effects = new List<Effect>();
            Status.Skills = new List<Skill>();
            StatusUnderEffects = new Status(Status);
        }

        public Status StatusUnderEffects { get; private set; }

        public string Name { get; private set; }

        protected List<Effect> Effects { get; set; }

        protected Status Status { get; set; }

        public void UseEffect(Effect effect)
        {
            Effect effectDuplicate = Effects.Find(i => i.GetType() == effect.GetType());
            if (effectDuplicate == null)
            {
                Effects.Add(effect);
            }
        }

        public bool IsLive()
        {
            return Status.HealthPoints > 0;
        }

        public void EffectsExposureStep()
        {
            StatusUnderEffects = new Status(Status);
            Effects.ForEach(i => i.Use(this));
            EffectsEnded();
            Status.HealthPoints = StatusUnderEffects.HealthPoints;
        }

        public void DealDamage(int damage)
        {
            Status.HealthPoints -= damage;
        }

        public void Step(IBattle battle)
        {
            StatusUnderEffects.Skills = StatusUnderEffects.Skills.FindAll(i => i.IsReady());
            int count = StatusUnderEffects.Skills.Count;
            if (count > 0)
            {
                int skillsActivID = (int)(rnd.Next() % count);
                StatusUnderEffects.Skills[skillsActivID].Use(battle.GetOpponent());
            }
            else
            {
                Logger.Log($"{Name} пропускает ход.");
            }
        }

        public void ClearEffects()
        {
            Effects.Clear();
        }

        public void RestartSkils()
        {
            Status.Skills.ForEach(i => i.Restart());
        }

        public void RestartHero()
        {
            ClearEffects();
            RestartSkils();
            Status.HealthPoints = Status.MaxHealthPoints;
        }

        private void EffectsEnded()
        {
            Effects = Effects.FindAll(i => !i.IsEnded());
        }
    }
}
