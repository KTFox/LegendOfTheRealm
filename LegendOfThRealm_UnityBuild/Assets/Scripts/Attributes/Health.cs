using System;
using UnityEngine;
using UnityEngine.Events;
using LegendOfTheRealm.Stats;
using LegendOfTheRealm.Utilities;

namespace LegendOfTheRealm.Attributes
{
    public class Health : MonoBehaviour
    {
        // Variables

        private float lastMaxHealth;
        private float lastCurrentHealth;
        private LazyValue<float> currentHealth;

        // Properties

        public float CurrentHealth => currentHealth.Value;
        public float MaxHealth => GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public float CurrentHealthFraction => CurrentHealth / MaxHealth;
        public float CurrentHealthPercentage => CurrentHealthFraction * 100;
        public bool IsDead => CurrentHealth <= 0f;

        // Events

        public event Action OnMaxHealthUpdated;
        public UnityEvent<float> OnHealthChanged;
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

        private void OnEnable()
        {
            GetComponent<BaseStat>().OnLevelUp += BaseStat_OnLevelUp;
        }

        private void OnDisable()
        {
            GetComponent<BaseStat>().OnLevelUp -= BaseStat_OnLevelUp;
        }

        private void BaseStat_OnLevelUp()
        {
            float healAmount = MaxHealth - CurrentHealth;
            Heal(healAmount);
        }

        private void Start()
        {
            lastCurrentHealth = CurrentHealth;
            lastMaxHealth = MaxHealth;
        }

        private void Update()
        {
            if (CurrentHealth != lastCurrentHealth)
            {
                OnHealthChanged?.Invoke(CurrentHealth - lastCurrentHealth);
                lastCurrentHealth = CurrentHealth;
            }

            if (MaxHealth != lastMaxHealth)
            {
                OnMaxHealthUpdated?.Invoke();
                lastMaxHealth = MaxHealth;
            }
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            currentHealth.Value = Mathf.Max(currentHealth.Value - damage, 0f);

            if (IsDead)
            {
                GainEXPFor(instigator);
                OnDeath?.Invoke();
            }
        }

        private void GainEXPFor(GameObject instigator)
        {
            Experience instigatorEXP = instigator.GetComponent<Experience>();
            if (instigatorEXP == null)
            {
                return;
            }

            float expReward = GetComponent<BaseStat>().GetValueOfStat(Stat.ExperienceReward);
            instigatorEXP.GainExperience(expReward);
        }

        public void Heal(float healingAmount)
        {
            currentHealth.Value = MathF.Min(MaxHealth, currentHealth.Value + healingAmount);
        }
    }
}
