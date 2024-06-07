using UnityEngine;

namespace LegendOfTheRealm
{
    public class PlayerMoveState : PlayerGroundedState
    {
        // Constructors

        public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

            player.SetVelocity(xInput * player.MoveSpeed, playerRb.velocity.y);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
