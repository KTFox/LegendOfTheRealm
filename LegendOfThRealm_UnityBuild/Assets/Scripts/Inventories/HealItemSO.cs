using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    [CreateAssetMenu(menuName = "InventoryItem/HealItem")]
    public class HealItemSO : UseableItemSO
    {
        [SerializeField] private float healAmount;

        public override void Use()
        {
            Player player = FindObjectOfType<Player>();
            player.GetComponent<Health>().Heal(healAmount);
        }
    }
}
