using LegendOfTheRealm.Inventories;
using LegendOfTheRealm.Players;
using LegendOfTheRealm.Utilities.UI;
using UnityEngine;

namespace LegendOfTheRealm.UI.Inventories
{
    public class EquipmentSlotUI : MonoBehaviour, IDragContainer<InventoryItemSO>
    {
        // Variables

        [SerializeField] private InventoryItemIcon icon;
        [SerializeField] private EquipmentLocation location;

        private Equipment playerEquipment;

        // Properties

        public InventoryItemSO Item => playerEquipment.GetItemIn(location);

        public int Quantity => Item == null ? 0 : 1;


        // Methods

        private void Awake()
        {
            playerEquipment = FindObjectOfType<Player>().GetComponent<Equipment>();

            playerEquipment.OnEquipmentUpdated += PlayerEquipment_OnEquipmentUpdated;
        }

        private void Start()
        {
            PlayerEquipment_OnEquipmentUpdated();
        }

        private void PlayerEquipment_OnEquipmentUpdated()
        {
            icon.SetItem(Item);
        }

        public void AddItems(InventoryItemSO item, int quantity)
        {
            playerEquipment.AddItem(location, item);
        }

        public void RemoveItems(int quantity)
        {
            playerEquipment.RemoveItem(location);
        }

        public int GetMaxAcceptable(InventoryItemSO item)
        {
            EquipableItemSO equipableItem = item as EquipableItemSO;

            if (location != equipableItem.Location || Item != null)
            {
                return 0;
            }

            return 1;
        }
    }
}
