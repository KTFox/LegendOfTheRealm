using LegendOfTheRealm.Stats;
using LegendOfTheRealm.Utilities;
using System;
using UnityEngine;
using UnityEngine.Events;
namespace LegendOfTheRealm.Attributes
{
    public class Health : MonoBehaviour
    {
        // Variables

        private LazyValue<float> currentHealth;

        // Properties

        public float CurrentHealth => currentHealth.Value;
        public float MaxHealth => GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public float CurrentHealthFraction => currentHealth.Value / MaxHealth;
        public float CurrentHealthPercentage => CurrentHealthFraction * 100;
        public bool IsDead => currentHealth.Value <= 0f;

        // Events

        public UnityEvent OnTakeDamage;
        public UnityEvent OnDeath;


        // Methods

        private void Awake()
        {
            currentHealth = new LazyValue<float>(GetInitialHealth);
        }

        private float GetInitialHealth()
        {
            return GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            currentHealth.Value = Mathf.Max(currentHealth.Value - damage, 0f);

            if (IsDead)
            {
                GainEXPFor(instigator);
                OnDeath?.Invoke();
            }
            else
            {
                OnTakeDamage?.Invoke();
            }
        }

        private void GainEXPFor(GameObject instigator)
        {
            Experience instigatorEXP = instigator.GetComponent<Experience>();
            if (instigatorEXP == null) return;

            instigatorEXP.GainExperience(GetComponent<BaseStat>().GetValueOfStat(Stat.ExperienceReward));
        }

        public void Heal(float healingAmount)
        {
            currentHealth.Value = MathF.Min(MaxHealth, currentHealth.Value + healingAmount);
        }
    }
}
