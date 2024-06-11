using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;


        // Methods

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}
