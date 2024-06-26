using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using LegendOfTheRealm.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LegendOfTheRealm.UI.Inventories
{
    public class StatusPanel : MonoBehaviour
    {
        // Variables

        [SerializeField] private Slider HPSlider;
        [SerializeField] private TextMeshProUGUI HPFraction;
        [SerializeField] private Slider MPSlider;
        [SerializeField] private TextMeshProUGUI MPFraction;
        [SerializeField] private Slider EXPSlider;
        [SerializeField] private TextMeshProUGUI EXPFraction;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI physicalDamgeStat;
        [SerializeField] private TextMeshProUGUI magicalDamgeStat;
        [SerializeField] private TextMeshProUGUI physicalDefenceStat;
        [SerializeField] private TextMeshProUGUI magicalDefenceStat;
        [SerializeField] private TextMeshProUGUI critalChanceStat;
        [SerializeField] private TextMeshProUGUI criticalBonusStat;

        private Health playerHealth;
        private BaseStat playerBaseStat;


        // Methods

        private void Start()
        {
            playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
            playerBaseStat = FindObjectOfType<Player>().GetComponent<BaseStat>();
        }

        private void Update()
        {
            HPSlider.value = playerHealth.CurrentHealthFraction;
            HPFraction.text = $"{playerHealth.CurrentHealth}/{playerHealth.MaxHealth}";
            // TO-DO: update MP value
            // TO-DO: update MP fraction value
            // TO-DO: update EXP value
            // TO-DO: update EXP fraction value
            // TO-DO: update level value
            physicalDamgeStat.text = playerBaseStat.GetValueOfStat(Stat.PhysicalDamage).ToString();
            magicalDamgeStat.text = playerBaseStat.GetValueOfStat(Stat.MagicalDamage).ToString();
            physicalDefenceStat.text = playerBaseStat.GetValueOfStat(Stat.PhysicalDefence).ToString();
            magicalDefenceStat.text = playerBaseStat.GetValueOfStat(Stat.MagicalDefence).ToString();
            critalChanceStat.text = playerBaseStat.GetValueOfStat(Stat.CriticalChance).ToString() + "%";
            criticalBonusStat.text = playerBaseStat.GetValueOfStat(Stat.CriticalBonus).ToString() + "%";
        }
    }
}
