using LegendOfTheRealm.Players;

namespace LegendOfTheRealm
{
    public class PlayerHeavyAttackState : PlayerState
    {
        public PlayerHeavyAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }

        public override void Enter()
        {
            base.Enter();

            player.SetVelocity(0f, 0f);
        }

        public override void Update()
        {
            base.Update();

            if (triggerCalled)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
