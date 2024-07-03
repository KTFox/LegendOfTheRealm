using LegendOfTheRealm.Skills;
using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class SkillManager : MonoBehaviour
    {
        // Variables

        public static SkillManager Instance;

        #region Skill
        #endregion


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
