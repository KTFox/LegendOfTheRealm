using DG.Tweening;
using LegendOfTheRealm.Attributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LegendOfTheRealm.UI
{
    public class EnemyHealthBar : MonoBehaviour
    {
        // Variables

        [SerializeField] private Image delayedHealthBar;

        private Health enemtHealth;
        private Slider healthSlider;

        private float timeToUpdateDelayedSlider = 1f;
        private float updateHealthBarTimer;


        // Methods

        private void Awake()
        {
            enemtHealth = GetComponentInParent<Health>();
            healthSlider = GetComponent<Slider>();
        }

        private void Start()
        {
            enemtHealth.OnTakeDamage.AddListener(UpdateHealthBar);

            UpdateHealthBar();

            delayedHealthBar.fillAmount = healthSlider.value;
        }

        private void Update()
        {
            updateHealthBarTimer -= Time.deltaTime;

            if (updateHealthBarTimer <= 0f && delayedHealthBar.fillAmount != healthSlider.value)
            {
                delayedHealthBar.DOFillAmount(healthSlider.value, 2f);
            }
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position - Camera.main.transform.position);
        }

        private void UpdateHealthBar()
        {
            healthSlider.value = enemtHealth.CurrentHealthFraction;
            updateHealthBarTimer = timeToUpdateDelayedSlider;
        }
    }
}
