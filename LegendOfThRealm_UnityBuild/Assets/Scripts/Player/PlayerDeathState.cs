namespace LegendOfTheRealm.Players
{
    public class PlayerDeathState : PlayerState
    {
        // Constructors

        public PlayerDeathState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();

            player.SetVelocity(0f, 0f);
        }
    }
}
