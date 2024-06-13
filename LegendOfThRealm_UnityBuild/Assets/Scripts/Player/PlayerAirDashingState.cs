namespace LegendOfTheRealm.Players
{
    public class PlayerAirDashingState : PlayerState
    {
        // Constructors

        public PlayerAirDashingState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.RollDuration;
        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(player.FacingDir * player.RollSpeed, 0f);

            if (stateTimer < 0)
            {
                stateMachine.ChangeState(player.JumpState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            player.SetVelocity(0f, playerRb.velocity.y);
        }
    }
}

