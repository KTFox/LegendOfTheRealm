using System;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    public class Equipment : MonoBehaviour
    {
        // Variables

        private Dictionary<EquipmentLocation, InventoryItemSO> equippedItems = new Dictionary<EquipmentLocation, InventoryItemSO>();

        // Events

        public event Action OnEquipmentUpdated;


        // Methods

        public InventoryItemSO GetItemIn(EquipmentLocation location)
        {
            if (!equippedItems.ContainsKey(location))
            {
                return null;
            }

            return equippedItems[location];
        }

        public void AddItem(EquipmentLocation location, InventoryItemSO item)
        {
            equippedItems[location] = item;

            OnEquipmentUpdated?.Invoke();
        }

        public void RemoveItem(EquipmentLocation location)
        {
            equippedItems.Remove(location);

            OnEquipmentUpdated?.Invoke();
        }
    }
}
