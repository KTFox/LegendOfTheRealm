using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    [CreateAssetMenu(menuName ="Inventory/EquipableItem")]
    public class EquipableItemSO : InventoryItemSO
    {
        [SerializeField] private EquipmentLocation location;

        public EquipmentLocation Location => location;
    }
}
