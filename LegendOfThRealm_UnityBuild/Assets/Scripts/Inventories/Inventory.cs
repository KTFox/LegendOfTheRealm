using LegendOfTheRealm.Players;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

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
        // public bool HasEmptySlot

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
        }

        public bool AddItemToSlot(int slotIndex, InventoryItemSO item, int quantity)
        {
            if (slots[slotIndex].Item != null)
            {
                return AddItemToFirstEmptySlot(item, quantity);
            }
        }

        private bool AddItemToFirstEmptySlot(InventoryItemSO item, int quantity)
        {

        }

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

        public bool HasSpaceFor(IEnumerable<InventoryItemSO> items)
        {
            int freeSlotsNumber = GetFreeSlotsNumber();
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

        public InventoryItemSO GetItemInSlot(int slotIndex)
        {
            return slots[slotIndex].Item;
        }

        public int GetItemQuantityInSlot(int index)
        {
            return slots[index].Quantity;
        }

        private int FindSlotIndex(InventoryItemSO item)
        {
            int i = FindStackIndex(item);

            if (i < 0)
            {
                i = FindFirstEmptySlotIndex();
            }

            return i;
        }

        private int FindFirstEmptySlotIndex()
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

        private int FindStackIndex(InventoryItemSO item)
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

        private int GetFreeSlotsNumber()
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
    }
}
