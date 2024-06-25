using UnityEngine;
using LegendOfTheRealm.Inventories;
using LegendOfTheRealm.Utilities.UI;

namespace LegendOfTheRealm.UI.Inventories
{
    public class InventorySlotUI : MonoBehaviour, IDragContainer<InventoryItemSO>
    {
        // Variables

        [SerializeField] private InventoryItemIcon inventoryItemIcon;

        private int slotIndex;
        private Inventory inventory;

        // Properties

        public InventoryItemSO Item => inventory.GetItemInSlot(slotIndex);
        public int Quantity => inventory.GetItemQuantityInSlot(slotIndex);


        // Methods

        public void SetUp(Inventory inventory, int slotIndex)
        {
            this.inventory = inventory;
            this.slotIndex = slotIndex;
            inventoryItemIcon.SetItem(inventory.GetItemInSlot(slotIndex), inventory.GetItemQuantityInSlot(slotIndex));
        }

        public void AddItems(InventoryItemSO item, int quantity)
        {
            inventory.AddItemToSlot(slotIndex, item, quantity);
        }

        public void RemoveItems(int quantity)
        {
            inventory.RemoveFromSlot(slotIndex, quantity);
        }

        public int GetMaxAcceptable(InventoryItemSO inventoryItemSO)
        {
            if (Item == null)
            {
                return int.MaxValue;
            }

            return 0;
        }
    }
}
