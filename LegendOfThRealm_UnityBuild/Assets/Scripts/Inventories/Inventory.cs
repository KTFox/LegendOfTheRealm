using UnityEngine;
using System;
using System.Collections.Generic;
using LegendOfTheRealm.Players;

namespace LegendOfTheRealm.Inventories
{
    public class Inventory : MonoBehaviour
    {
        // Variables

        [SerializeField] private int size;

        private InventorySlot[] slots;

        // Properties

        public static Inventory PlayerInventory => FindObjectOfType<Player>().GetComponent<Inventory>();
        public int Size => size;
        public bool HasEmptySlot => GetFreeSlotsAmount() > 0;

        // Events

        public event Action OnInventoryUpdated;

        // Structs

        [System.Serializable]
        private struct InventorySlot
        {
            public InventoryItemSO Item;
            public int Quantity;
        }


        // Methods

        private void Awake()
        {
            slots = new InventorySlot[size];

            slots[0].Item = InventoryItemSO.GetItemFromID("0ee9dc36-54e4-43a1-b42f-0d657e46bea0");
            slots[0].Quantity = 1;

            slots[1].Item = InventoryItemSO.GetItemFromID("15e429cb-95e2-4592-acdd-9ccfffca1654");
            slots[1].Quantity = 1;

            slots[2].Item = InventoryItemSO.GetItemFromID("be79b38a-7596-4aec-ad79-db014a1bafbb");
            slots[2].Quantity = 1;

            slots[3].Item = InventoryItemSO.GetItemFromID("544b5650-b2aa-48aa-8110-640562bf48be");
            slots[3].Quantity = 1;

            slots[4].Item = InventoryItemSO.GetItemFromID("61eb863d-6451-4427-8278-208fa8b94657");
            slots[4].Quantity = 1;

            slots[5].Item = InventoryItemSO.GetItemFromID("30e1bb26-200d-4186-bbb7-5cfc79cd4284");
            slots[5].Quantity = 1;

            slots[6].Item = InventoryItemSO.GetItemFromID("f1bcb013-b2f0-4421-a5b3-e02ed615d709");
            slots[6].Quantity = 1;
        }

        public bool AddItemToSlot(int slotIndex, InventoryItemSO item, int quantity)
        {
            slots[slotIndex].Item = item;
            slots[slotIndex].Quantity += quantity;

            OnInventoryUpdated?.Invoke();

            return true;
        }

        public bool AddItemToFirstEmptySlot(InventoryItemSO item, int quantity)
        {
            int index = GetAvailableSlotIndexFor(item);

            if (index < 0)
            {
                return false;
            }

            slots[index].Item = item;
            slots[index].Quantity += quantity;

            OnInventoryUpdated?.Invoke();

            return true;
        }

        #region AddItemToFirstEmptySlot details
        private int GetAvailableSlotIndexFor(InventoryItemSO item)
        {
            int i = GetFirstStackedSlotIndexOf(item);

            if (i < 0)
            {
                i = GetFirstEmptySlotIndex();
            }

            return i;
        }

        private int GetFirstStackedSlotIndexOf(InventoryItemSO item)
        {
            if (!item.Stackable)
            {
                return -1;
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (ReferenceEquals(slots[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        private int GetFirstEmptySlotIndex()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].Item == null)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion

        public void RemoveFromSlot(int slotIndex, int quantity)
        {
            slots[slotIndex].Quantity -= quantity;

            if (slots[slotIndex].Quantity <= 0)
            {
                slots[slotIndex].Item = null;
                slots[slotIndex].Quantity = 0;
            }

            OnInventoryUpdated?.Invoke();
        }

        public bool HasEnoughSpaceFor(IEnumerable<InventoryItemSO> items)
        {
            int freeSlotsNumber = GetFreeSlotsAmount();
            var stackedItems = new List<InventoryItemSO>();

            foreach (InventoryItemSO item in items)
            {
                if (item.Stackable)
                {
                    if (HasItem(item)) continue;
                    if (stackedItems.Contains(item)) continue;

                    stackedItems.Add(item);
                }

                if (freeSlotsNumber <= 0)
                {
                    return false;
                }

                freeSlotsNumber--;
            }

            return true;
        }

        #region HasEnoughSpaceFor details
        /// <summary>
        /// Returns the number of slots with no items inside.
        /// </summary>
        /// <returns></returns>
        private int GetFreeSlotsAmount()
        {
            int count = 0;

            foreach (InventorySlot slot in slots)
            {
                if (slot.Quantity == 0)
                {
                    count++;
                }
            }

            return count;
        }

        private bool HasItem(InventoryItemSO item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (ReferenceEquals(slots[i].Item, item))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        public InventoryItemSO GetItemInSlot(int slotIndex)
        {
            return slots[slotIndex].Item;
        }

        public int GetItemQuantityInSlot(int index)
        {
            return slots[index].Quantity;
        }
    }
}
