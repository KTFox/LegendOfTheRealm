using DG.Tweening;
using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
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
        private float updateHealthBarTimer;


        // Methods

        private void Start()
        {
            player = FindObjectOfType<Player>();
            playerHealth = player.GetComponent<Health>();

            playerHealth.OnTakeDamage.AddListener(UpdateHealthSlider);

            UpdateHealthSlider();

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

        private void UpdateHealthSlider()
        {
            healthSlider.value = playerHealth.CurrentHealthFraction;
            updateHealthBarTimer = timeToUpdateDelayedSlider;
        }
    }
}
