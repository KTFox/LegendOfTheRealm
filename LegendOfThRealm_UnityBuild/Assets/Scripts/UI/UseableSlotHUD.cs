using LegendOfTheRealm.Inventories;
using LegendOfTheRealm.Players;
using LegendOfTheRealm.UI.Inventories;
using UnityEngine;

namespace LegendOfTheRealm.UI
{
    public class UseableSlotHUD : MonoBehaviour
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
    }
}
