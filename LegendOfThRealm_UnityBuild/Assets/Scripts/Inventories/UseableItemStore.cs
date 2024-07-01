using System;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    public class UseableItemStore : MonoBehaviour
    {
        // Variables

        private Dictionary<int, UseableItemSlot> useableItemSlots = new Dictionary<int, UseableItemSlot>();

        // Structs

        [System.Serializable]
        private class UseableItemSlot
        {
            public UseableItemSO Item;
            public int Quantity;
        }

        // Events

        public event Action OnUseableItemStoreUpdated;


        // Methods

        public void UseItemIn(int slotIndex)
        {
            if (useableItemSlots.ContainsKey(slotIndex))
            {
                useableItemSlots[slotIndex].Item.Use();

                RemoveItem(slotIndex, 1);
            }
        }

        public void AddItem(int slotIndex, InventoryItemSO item, int quantity)
        {
            if (useableItemSlots.ContainsKey(slotIndex))
            {
                if (ReferenceEquals(useableItemSlots[slotIndex].Item, item))
                {
                    useableItemSlots[slotIndex].Quantity += quantity;
                }
            }
            else
            {
                var usableItemSlot = new UseableItemSlot();
                usableItemSlot.Item = item as UseableItemSO;
                usableItemSlot.Quantity = quantity;

                useableItemSlots[slotIndex] = usableItemSlot;
            }

            OnUseableItemStoreUpdated?.Invoke();
        }

        public void RemoveItem(int slotIndex, int quantity)
        {
            if (useableItemSlots.ContainsKey(slotIndex))
            {
                useableItemSlots[slotIndex].Quantity -= quantity;

                if (useableItemSlots[slotIndex].Quantity <= 0)
                {
                    useableItemSlots.Remove(slotIndex);
                }

                OnUseableItemStoreUpdated?.Invoke();
            }
        }

        public UseableItemSO GetItemIn(int slotIndex)
        {
            if (useableItemSlots.ContainsKey(slotIndex))
            {
                return useableItemSlots[slotIndex].Item;
            }

            return null;
        }

        public int GetItemQuantityIn(int slotIndex)
        {
            if (useableItemSlots.ContainsKey(slotIndex))
            {
                return useableItemSlots[slotIndex].Quantity;
            }

            return 0;
        }
    }
}
