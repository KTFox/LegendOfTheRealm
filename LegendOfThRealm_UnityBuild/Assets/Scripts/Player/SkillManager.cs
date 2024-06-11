using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager Instance;


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
