using LegendOfTheRealm.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    [CreateAssetMenu(menuName = "InventoryItem/EquipableItem")]
    public class EquipableItemSO : InventoryItemSO, IModifierProvider
    {
        // Variables

        [SerializeField] private EquipmentLocation location;
        [SerializeField] private Modifier[] additiveModifiers;
        [SerializeField] private Modifier[] percentageModifiers;

        // Properties

        public EquipmentLocation Location => location;

        // Structs

        [System.Serializable]
        private struct Modifier
        {
            public Stat stat;
            public float value;
        }


        // Methods

        #region IModifierProvider implements

        IEnumerable<float> IModifierProvider.GetAdditiveModifiers(Stat stat)
        {
            foreach (var modifier in additiveModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }

        IEnumerable<float> IModifierProvider.GetPercentageModifiers(Stat stat)
        {
            foreach (var modifier in percentageModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }
        #endregion
    }
}
