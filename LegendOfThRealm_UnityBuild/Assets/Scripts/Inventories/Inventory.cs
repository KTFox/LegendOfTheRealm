using LegendOfTheRealm.Players;
using Unity.VisualScripting;
using UnityEngine;

namespace LegendOfTheRealm.Inventories
{
    public class Inventory : MonoBehaviour
    {
        // Variables

        [SerializeField] private int size;

        // Properties

        public static Inventory PlayerInventory => FindObjectOfType<Player>().GetComponent<Inventory>();
        public int Size => size;
    }
}
