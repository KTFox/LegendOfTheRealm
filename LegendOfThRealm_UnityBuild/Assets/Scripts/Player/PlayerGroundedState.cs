using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerGroundedState : PlayerState
    {
        // Constructors

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

            if (Input.GetKeyDown(KeyCode.J))
            {
                stateMachine.ChangeState(player.primaryAttackState);
            }

            if (Input.GetKeyDown(KeyCode.K) && player.IsGround)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, player.JumpForce);
            }

            if (!player.IsGround)
            {
                stateMachine.ChangeState(player.jumpState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
