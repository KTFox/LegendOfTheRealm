using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerPrimaryAttackState : PlayerState
    {
        // Variables

        private int comboCounter;
        private float lastTimeAttacked;
        private float comboWindow = 1f;

        // Constructors

        public PlayerPrimaryAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            {
                comboCounter = 0;
            }

            player.animator.SetInteger("ComboCounter", comboCounter);

            float attackDir = player.FacingDir;
            if (xInput != 0)
            {
                attackDir = xInput;
            }
            player.SetVelocity(player.AttackMovements[comboCounter].x * attackDir, player.AttackMovements[comboCounter].y);

            stateTimer = 0.1f;
        }

        public override void Update()
        {
            base.Update();

            if (stateTimer < 0)
            {
                player.SetVelocity(0f, 0f);
            }

            if (triggerCalled)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            lastTimeAttacked = Time.time;
            comboCounter++;
        }
    }
}
