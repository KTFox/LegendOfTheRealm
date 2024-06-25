using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    public class InventoryItemSO : ScriptableObject
    {
        // Variables

        [SerializeField] private string itemID;
        [SerializeField] private string displayName;
        [SerializeField][TextArea] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField] private bool stackable;
        [SerializeField] private float price;

        private static Dictionary<string, InventoryItemSO> itemLookupTable;

        // Properties

        public string ItemID => itemID;
        public string DisplayName => displayName;
        public string Description => description;
        public Sprite Icon => icon;
        public bool Stackable => stackable;
        public float Price => price;


        // Methods

        public static InventoryItemSO GetItemFromID(string id)
        {
            if (itemLookupTable == null)
            {
                itemLookupTable = new Dictionary<string, InventoryItemSO>();
                var itemList = Resources.LoadAll<InventoryItemSO>("");

                foreach (var item in itemList)
                {
                    if (itemLookupTable.ContainsKey(item.itemID))
                    {
                        Debug.LogError($"It looks like that Item({item.itemID}) in Resources folder has been duplicated");
                        continue;
                    }

                    itemLookupTable[item.itemID] = item;
                }
            }

            if (id == null || !itemLookupTable.ContainsKey(id))
            {
                return null;
            }

            return itemLookupTable[id];
        }
    }
}
