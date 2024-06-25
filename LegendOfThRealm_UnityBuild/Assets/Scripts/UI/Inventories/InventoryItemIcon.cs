using LegendOfTheRealm.Inventories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LegendOfTheRealm.UI.Inventories
{
    public class InventoryItemIcon : MonoBehaviour
    {
        // Variables

        [SerializeField] private GameObject itemQuantityTextContainer;
        [SerializeField] private TextMeshProUGUI itemQuantityText;


        // Methods

        public void SetItem(InventoryItemSO inventoryItemSO)
        {
            SetItem(inventoryItemSO, 0);
        }

        public void SetItem(InventoryItemSO inventoryItemSO, int quantity)
        {
            var itemImage = GetComponent<Image>();

            if (inventoryItemSO == null)
            {
                itemImage.enabled = false;
            }
            else
            {
                itemImage.enabled = true;
                itemImage.sprite = inventoryItemSO.Icon;
            }

            if (itemQuantityText)
            {
                if (quantity <= 1)
                {
                    itemQuantityTextContainer.SetActive(false);
                }
                else
                {
                    itemQuantityTextContainer.SetActive(true);
                    itemQuantityText.text = quantity.ToString();
                }
            }
        }
    }
}
