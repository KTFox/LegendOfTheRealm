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
        }

        public override void Update()
        {
            base.Update();

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
