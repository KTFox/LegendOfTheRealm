using LegendOfTheRealm.Managers;

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

            // TO-DO: change input

            //if (InputManager.Instance.IsQKeyDown())
            //{
            //    stateMachine.ChangeState(player.CounterAttackState);
            //}

            //if (InputManager.Instance.IsLeftMouseButtonDown())
            //{
            //    stateMachine.ChangeState(player.PrimaryAttackState);
            //}

            if (!player.IsGroundDetected)
            {
                stateMachine.ChangeState(player.JumpState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void OnJump()
        {
            base.OnJump();

            if (player.IsGroundDetected)
            {
                player.SetVelocity(playerRb.velocity.x, player.JumpForce);
            }
        }
    }
}
