using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
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

            player.SetVelocity(InputManager.Instance.GetHorizontalInput() * player.MoveSpeed, playerRb.velocity.y);

            if (InputManager.Instance.GetHorizontalInput() == 0)
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
