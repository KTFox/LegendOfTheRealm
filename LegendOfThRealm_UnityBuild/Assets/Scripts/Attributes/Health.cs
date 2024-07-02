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

        private float lastMaxHealth;
        private float lastCurrentHealth;
        private LazyValue<float> currentHealth;

        // Properties

        public float CurrentHealth => currentHealth.Value;
        public float MaxHealth => GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public float CurrentHealthFraction => currentHealth.Value / MaxHealth;
        public float CurrentHealthPercentage => CurrentHealthFraction * 100;
        public bool IsDead => currentHealth.Value <= 0f;

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
            lastCurrentHealth = currentHealth.Value;
            lastMaxHealth = MaxHealth;
        }

        private void Update()
        {
            if (currentHealth.Value != lastCurrentHealth)
            {
                OnHealthChanged?.Invoke(currentHealth.Value - lastCurrentHealth);

                lastCurrentHealth = currentHealth.Value;
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
            if (instigatorEXP == null) return;

            instigatorEXP.GainExperience(GetComponent<BaseStat>().GetValueOfStat(Stat.ExperienceReward));
        }

        public void Heal(float healingAmount)
        {
            currentHealth.Value = MathF.Min(MaxHealth, currentHealth.Value + healingAmount);
        }
    }
}
