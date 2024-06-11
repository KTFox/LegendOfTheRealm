using LegendOfTheRealm.Skills;
using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager Instance;

        #region Skill
        public DashSkill DashSkill { get; private set; }
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

            DashSkill = GetComponent<DashSkill>();
        }
    }
}
