using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class DashSkill : Skill
    {
        // Methods

        protected override void UseSkill()
        {
            base.UseSkill();

            Debug.Log("Clone ghost image behind.");
        }
    }
}
