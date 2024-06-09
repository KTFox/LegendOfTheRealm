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

            stateTimer = bandit.IdleTime;
        }

        public override void Update()
        {
            base.Update();

            if (stateTimer <= 0)
            {
                stateMachine.ChangeState(bandit.MoveState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
