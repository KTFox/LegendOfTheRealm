using LegendOfTheRealm.Inventories;
using LegendOfTheRealm.Utilities.UI;
using UnityEngine;

namespace LegendOfTheRealm.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour, IDragContainer<InventoryItemSO>
    {
        // Variables

        [SerializeField] private InventoryItemIcon inventoryItemIcon;

        private int slotIndex;
        private Inventory inventory;

        // Properties

        public InventoryItemSO InventoryItemSO => inventory.GetItemInSlot(slotIndex);
        public int ItemQuantity => inventory.GetItemQuantityInSlot(slotIndex);


        // Methods

        public void SetUp(Inventory inventory, int slotIndex)
        {
            this.inventory = inventory;
            this.slotIndex = slotIndex;
            inventoryItemIcon.SetItem(inventory.GetItemInSlot(slotIndex), inventory.GetItemQuantityInSlot(slotIndex));
        }

        public void AddItems(InventoryItemSO inventoryItemSO, int quantity)
        {
            inventory.AddItemToSlot(slotIndex, inventoryItemSO, quantity);
        }

        public void RemoveItems(int quantity)
        {
            inventory.RemoveFromSlot(slotIndex, quantity);
        }

        public int GetMaxAcceptable(InventoryItemSO inventoryItemSO)
        {
            if (InventoryItemSO == null)
            {
                return int.MaxValue;
            }

            return 0;
        }
    }
}
