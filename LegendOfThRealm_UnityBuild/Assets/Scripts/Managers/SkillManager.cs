using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class SkillManager : MonoBehaviour
    {
        // Variables

        public static SkillManager Instance;

        #region Skills
        public HeavyAttackSkill HeavyAttackSkill { get; private set; }
        #endregion


        // Methods

        private void Awake()
        {
            Instance = this;

            HeavyAttackSkill = GetComponent<HeavyAttackSkill>();
        }
    }
}
