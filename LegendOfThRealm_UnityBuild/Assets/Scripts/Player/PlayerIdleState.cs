using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
{
    public class PlayerIdleState : PlayerGroundedState
    {
        // Constructors

        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

            if (inputManger.GetNormallizedMovementVector().x != 0 && !player.IsBusy)
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
