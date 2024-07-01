using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    [CreateAssetMenu(menuName = "InventoryItem/RestoreManaItem")]
    public class RestoreManaItemSO : UseableItemSO
    {
        [SerializeField] private float restoreManaAmount;

        public override void Use()
        {
            Debug.Log($"Restore {restoreManaAmount}");
        }
    }
}
