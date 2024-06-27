using LegendOfTheRealm.Stats;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    public class Equipment : MonoBehaviour, IModifierProvider
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

        #region IModifierProvider implements
        IEnumerable<float> IModifierProvider.GetAdditiveModifiers(Stat stat)
        {
            foreach (EquipmentLocation location in equippedItems.Keys)
            {
                IModifierProvider provider = (EquipableItemSO)equippedItems[location];
                foreach (float modifier in provider.GetAdditiveModifiers(stat))
                {
                    yield return modifier;
                }
            }
        }

        IEnumerable<float> IModifierProvider.GetPercentageModifiers(Stat stat)
        {
            foreach (EquipmentLocation location in equippedItems.Keys)
            {
                IModifierProvider provider = (EquipableItemSO)equippedItems[location];
                foreach (float modifier in provider.GetPercentageModifiers(stat))
                {
                    yield return modifier;
                }
            }
        }
        #endregion
    }
}
