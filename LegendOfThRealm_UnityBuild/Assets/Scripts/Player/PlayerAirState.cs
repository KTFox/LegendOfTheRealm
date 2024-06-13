using LegendOfTheRealm.Managers;

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

            player.SetVelocity(inputManger.GetNormallizedMovementVector().x * player.MoveSpeed, playerRb.velocity.y);

            if (player.IsGroundDetected)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
