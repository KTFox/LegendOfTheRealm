using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class HeavyAttackSkill : Skill
    {
        public override void Use()
        {
            base.Use();

            if (cooldownTimer > 0)
            {
                return;
            }

            cooldownTimer = cooldown;

            if (player.IsGroundDetected)
            {
                player.StateMachine.ChangeState(player.HeavyAttackState);
            }
        }
    }
}
