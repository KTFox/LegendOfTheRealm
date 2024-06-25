using UnityEngine;
using LegendOfTheRealm.Inventories;

namespace LegendOfTheRealm.UI.Inventories
{
    public class InventoryUI : MonoBehaviour
    {
        // Variables

        [SerializeField] private InventorySlotUI inventorySlotPrefab;

        private Inventory playerInventory;


        // Methods

        private void Awake()
        {
            playerInventory = Inventory.PlayerInventory;
        }

        private void OnEnable()
        {
            playerInventory.OnInventoryUpdated += PlayerInventory_InventoryUpdated;
        }

        private void Start()
        {
            PlayerInventory_InventoryUpdated();
        }

        void PlayerInventory_InventoryUpdated()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < playerInventory.Size; i++)
            {
                var inventorySlotUI = Instantiate(inventorySlotPrefab, transform);
                inventorySlotUI.SetUp(playerInventory, i);
            }
        }
    }
}

