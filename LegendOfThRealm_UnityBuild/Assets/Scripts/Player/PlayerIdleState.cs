using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerIdleState : PlayerGroundedState
    {
        // Constructors

        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {

        }


        // Methods

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            if (xInput != 0)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
