namespace LegendOfTheRealm.Players
{
    public class PlayerGroundedState : PlayerState
    {
        // Constructors

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

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

        public override void OnAttack()
        {
            base.OnAttack();

            stateMachine.ChangeState(player.PrimaryAttackState);
        }

        public override void OnCounterAttack()
        {
            base.OnCounterAttack();

            stateMachine.ChangeState(player.CounterAttackState);
        }
    }
}
