using DG.Tweening;
using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LegendOfTheRealm.UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        // Variables

        [SerializeField] private Slider healthSlider;
        [SerializeField] private Image delayedHealthBar;

        private Player player;
        private Health playerHealth;

        private float timeToUpdateDelayedSlider = 1f;


        // Methods

        private void Start()
        {
            player = FindObjectOfType<Player>();
            playerHealth = player.GetComponent<Health>();

            playerHealth.OnHealthChanged.AddListener((x) =>
            {
                StopAllCoroutines();
                StartCoroutine(UpdateHealthSliderCoroutine(x));
            });

            playerHealth.OnMaxHealthUpdated += PlayerHealth_OnMaxHealthUpdated;

            UpdateSliderFraction();
        }

        private void PlayerHealth_OnMaxHealthUpdated()
        {
            UpdateSliderFraction();
        }

        private IEnumerator UpdateHealthSliderCoroutine(float healthChangeAmount)
        {
            if (healthChangeAmount < 0f)
            {
                healthSlider.value = playerHealth.CurrentHealthFraction;
            }
            else
            {
                delayedHealthBar.fillAmount = playerHealth.CurrentHealthFraction;
            }

            yield return new WaitForSeconds(timeToUpdateDelayedSlider);

            if (healthChangeAmount < 0f)
            {
                healthSlider.value = playerHealth.CurrentHealthFraction;
                delayedHealthBar.DOFillAmount(healthSlider.value, 2f);
            }
            else
            {
                delayedHealthBar.fillAmount = playerHealth.CurrentHealthFraction;
                healthSlider.DOValue(delayedHealthBar.fillAmount, 2f);
            }
        }

        private void UpdateSliderFraction()
        {
            healthSlider.value = playerHealth.CurrentHealthFraction;
            delayedHealthBar.fillAmount = healthSlider.value;
        }
    }
}
