using LegendOfTheRealm.Stats;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace LegendOfTheRealm.Attributes
{
    public class Health : MonoBehaviour
    {
        // Variables

        private float currentHealth;
        private bool wasDeadLastFrame;

        // Properties

        public float CurrentHealth => currentHealth;
        public float CurrentHealthFraction => currentHealth / GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public float CurrentHealthPercentage => CurrentHealthFraction * 100;
        public float MaxHealth => GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public bool IsDead => currentHealth <= 0f;

        // Events

        public UnityEvent OnDeath;

        [SerializeField]
        private UnityEvent<float> OnTakingDamage;


        // Methods



        public void TakeDamage(GameObject instigator, float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0f);

            if (IsDead)
            {
                AwardExperience(instigator);
                OnDeath?.Invoke();
            }
            else
            {
                OnTakingDamage?.Invoke(damage);
            }
        }

        public void Heal(float healingAmount)
        {
            currentHealth = MathF.Min(MaxHealth, currentHealth + healingAmount);
        }

        private void AwardExperience(GameObject instigator)
        {
            var instigatorExperience = instigator.GetComponent<Experience>();
            if (instigatorExperience == null) return;

            instigatorExperience.GainExperience(GetComponent<BaseStat>().GetValueOfStat(Stat.ExperienceReward));
        }
    }
}
