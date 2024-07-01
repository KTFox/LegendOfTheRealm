using UnityEngine;
using LegendOfTheRealm.Inventories;
using LegendOfTheRealm.Utilities.UI;
using LegendOfTheRealm.Players;

namespace LegendOfTheRealm.UI.Inventories
{
    public class UseableSlotUI : MonoBehaviour, IDragContainer<InventoryItemSO>
    {
        // Variables

        [SerializeField] private InventoryItemIcon icon;
        [SerializeField] private int slotIndex;

        private UseableItemStore useableItemStore;

        // Properties

        public InventoryItemSO Item => useableItemStore.GetItemIn(slotIndex);
        public int Quantity => useableItemStore.GetItemQuantityIn(slotIndex);


        // Methods

        private void Start()
        {
            useableItemStore = FindObjectOfType<Player>().GetComponent<UseableItemStore>();

            useableItemStore.OnUseableItemStoreUpdated += UseableItemStore_OnUseableItemStoreUpdated;
        }

        private void UseableItemStore_OnUseableItemStoreUpdated()
        {
            icon.SetItem(Item, Quantity);
        }

        public void AddItems(InventoryItemSO item, int quantity)
        {
            useableItemStore.AddItem(slotIndex, item, quantity);
        }

        public void RemoveItems(int quantity)
        {
            useableItemStore.RemoveItem(slotIndex, quantity);
        }

        public int GetMaxAcceptable(InventoryItemSO item)
        {
            if (Item == null || Item.Stackable)
            {
                return int.MaxValue;
            }

            return 0;
        }
    }
}
