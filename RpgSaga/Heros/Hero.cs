namespace RpgSaga.Heros
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Skills;

    public abstract class Hero : LoggerConnect, IHero
     {
        private Random rnd = new Random();
        private List<Skill> skillsActiv;

        public Hero(int healthPoints, int damage, string name, ILogger logger)
            : base(logger)
        {
            this.HealthPoints = healthPoints;
            this.MaxHealthPoints = healthPoints;
            this.Damage = damage;
            this.Name = name;
            Effects = new List<Effect>();
            Skills = new List<Skill>();
        }

        public string Name { get; private set; }

        public int Damage { get; private set; }

        protected List<Effect> Effects { get; set; } // массив эффектов

        protected List<Skill> Skills { get; set; } // массив скилjd

        protected int HealthPoints { get; private set; }

        protected int MaxHealthPoints { get; private set; }

        public void DealDamage(int damage)
        {
            HealthPoints -= damage;
        }

        public void UseEffect(Effect effect) // использовать эффф на героя
        {
            Effect effectDuplicate = Effects.Find(i => i.GetType() == effect.GetType());
            if (effectDuplicate == null)
            {
                Effects.Add(effect);
            }
        }

        public bool IsLive() // проверка что герой жив
        {
            return HealthPoints > 0;
        }

        public void HodEffects() // тик эффект
        {
            Effects.ForEach(i => i.Use(this));
            skillsActiv = Skills.FindAll(skill => Effects.TrueForAll(effect => effect.SkillUse(skill)));
            EffectsEnded();
        }

        public void Hod(IBattle battle) // шаг игрока
        {
            skillsActiv = skillsActiv.FindAll(i => i.IsReady());
            int count = skillsActiv.Count;
            if (count > 0)
            {
                int skillsActivID = (int)(rnd.Next() % count);
                skillsActiv[skillsActivID].Use(battle.GetOpponent());
            }
            else
            {
                Logger.Log($"{Name} пропускает ход.");
            }
        }

        public void ClearEffects() // очистить эффект
        {
            Effects.Clear();
        }

        public void RestartSkils() // рестрат скилды
        {
            Skills.ForEach(i => i.Restart());
        }

        public void RestartHero()
        {
            ClearEffects();
            RestartSkils();
            HealthPoints = MaxHealthPoints;
        }

        private void EffectsEnded() // проверить закончнных эффетов
        {
            Effects = Effects.FindAll(i => !i.IsEnded());
        }
    }
}
