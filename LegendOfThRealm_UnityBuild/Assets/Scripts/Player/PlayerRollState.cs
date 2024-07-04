namespace LegendOfTheRealm.Players
{
    public class PlayerRollState : PlayerState
    {
        // Variables

        private float rollDir;

        // Constructors

        public PlayerRollState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.RollDuration;

            if (inputManger.GetNormallizedMovementVector().x != 0)
            {
                rollDir = inputManger.GetNormallizedMovementVector().x;
            }
            else
            {
                rollDir = player.FacingDir;
            }
        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(rollDir * player.RollSpeed, 0f);

            if (stateTimer < 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            player.SetVelocity(0f, playerRb.velocity.y);
        }
    }
}
