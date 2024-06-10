namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditSuspiciousState : EnemyState
    {
        // Variables

        private Bandit bandit;

        // Constructors

        public BanditSuspiciousState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = bandit.SuspiciousTime;
        }

        public override void Update()
        {
            base.Update();

            if (bandit.IsPlayerDetected)
            {
                stateMachine.ChangeState(bandit.ChaseState);
            }

            if (stateTimer <= 0f)
            {
                stateMachine.ChangeState(bandit.WalkAroundState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
