using LegendOfTheRealm.Skills;
using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class SkillManager : MonoBehaviour
    {
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
