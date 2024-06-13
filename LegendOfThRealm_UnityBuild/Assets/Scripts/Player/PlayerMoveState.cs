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

            // TO-DO: change input

            player.SetVelocity(inputManger.GetNormallizedMovementVector().x * player.MoveSpeed, playerRb.velocity.y);

            if (inputManger.GetNormallizedMovementVector().x == 0)
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
