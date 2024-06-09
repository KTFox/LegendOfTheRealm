namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditIdleState : EnemyState
    {
        // Variables

        private Bandit bandit;

        // Constructors

        public BanditIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
