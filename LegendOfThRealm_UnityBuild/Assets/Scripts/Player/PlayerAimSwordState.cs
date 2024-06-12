using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
{
    public class PlayerAimSwordState : PlayerState
    {
        // Constructor

        public PlayerAimSwordState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

            if (InputManager.Instance.IsRightMouseButtonUp())
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
