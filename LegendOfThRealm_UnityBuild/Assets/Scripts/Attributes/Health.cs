using LegendOfTheRealm.Stats;
using System;
using UnityEngine;
namespace LegendOfTheRealm.Attributes
{
    public class Health : MonoBehaviour
    {
        // Variables

        private float currentHealth;

        // Properties

        public float CurrentHealth => currentHealth;
        public float CurrentHealthFraction => currentHealth / GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public float CurrentHealthPercentage => CurrentHealthFraction * 100;
        public float MaxHealth => GetComponent<BaseStat>().GetValueOfStat(Stat.Health);
        public bool IsDead => currentHealth <= 0f;


        // Methods

        private void Start()
        {
            currentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0f);
        }

        public void Heal(float healingAmount)
        {
            currentHealth = MathF.Min(MaxHealth, currentHealth + healingAmount);
        }
    }
}
