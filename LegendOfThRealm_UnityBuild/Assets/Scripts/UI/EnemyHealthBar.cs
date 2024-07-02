using DG.Tweening;
using LegendOfTheRealm.Attributes;
using System.Collections;
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


        // Methods

        private void Awake()
        {
            enemtHealth = GetComponentInParent<Health>();
            healthSlider = GetComponent<Slider>();
        }

        private void Start()
        {
            enemtHealth.OnHealthChanged.AddListener((x) =>
            {
                StartCoroutine(UpdateHealthSliderCoroutine(x));
            });

            healthSlider.value = enemtHealth.CurrentHealthFraction;
            delayedHealthBar.fillAmount = healthSlider.value;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position - Camera.main.transform.position);
        }

        private IEnumerator UpdateHealthSliderCoroutine(float healthChangeAmount)
        {
            if (healthChangeAmount < 0f)
            {
                healthSlider.value = enemtHealth.CurrentHealthFraction;
            }
            else
            {
                delayedHealthBar.fillAmount = enemtHealth.CurrentHealthFraction;
            }

            yield return new WaitForSeconds(timeToUpdateDelayedSlider);

            if (healthChangeAmount < 0f)
            {
                healthSlider.value = enemtHealth.CurrentHealthFraction;
                delayedHealthBar.DOFillAmount(healthSlider.value, 2f);
            }
            else
            {
                delayedHealthBar.fillAmount = enemtHealth.CurrentHealthFraction;
                healthSlider.DOValue(delayedHealthBar.fillAmount, 2f);
            }
        }
    }
}
