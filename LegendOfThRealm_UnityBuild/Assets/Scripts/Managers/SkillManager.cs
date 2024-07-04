using LegendOfTheRealm.Skills;
using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class SkillManager : MonoBehaviour
    {
        // Variables

        public static SkillManager Instance;

        #region Skills
        public DashSkill DashSkill { get; private set; }
        public HeavyAttackSkill HeavyAttackSkill { get; private set; }
        #endregion


        // Methods

        private void Awake()
        {
            Instance = this;

            DashSkill = GetComponent<DashSkill>();
            HeavyAttackSkill = GetComponent<HeavyAttackSkill>();
        }
    }
}
