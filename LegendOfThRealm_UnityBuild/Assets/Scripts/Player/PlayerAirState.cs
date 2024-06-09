using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerAirState : PlayerState
    {
        // Constructors

        public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

            if (player.IsGround)
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