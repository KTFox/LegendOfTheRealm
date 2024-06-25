using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LegendOfTheRealm.Inventories;

namespace LegendOfTheRealm.UI.Inventories
{
    [RequireComponent(typeof(Image))]
    public class InventoryItemIcon : MonoBehaviour
    {
        // Variables

        [SerializeField] private GameObject itemQuantityTextContainer;
        [SerializeField] private TextMeshProUGUI itemQuantityText;


        // Methods

        public void SetItem(InventoryItemSO item)
        {
            SetItem(item, 0);
        }

        public void SetItem(InventoryItemSO item, int quantity)
        {
            var itemImage = GetComponent<Image>();

            if (item == null)
            {
                itemImage.enabled = false;
            }
            else
            {
                itemImage.enabled = true;
                itemImage.sprite = item.Icon;
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
