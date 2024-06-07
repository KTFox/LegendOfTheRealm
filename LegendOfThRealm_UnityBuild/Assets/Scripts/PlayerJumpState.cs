using UnityEngine;

namespace LegendOfTheRealm
{
    public class PlayerJumpState : PlayerState
    {
        // Constructors

        public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            playerRb.velocity = new Vector2(playerRb.velocity.x, player.JumpForce);
        }

        public override void Update()
        {
            base.Update();

            if (playerRb.velocity.y < 0f)
            {
                stateMachine.ChangeState(player.airState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
