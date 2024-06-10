namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditIDwellState : EnemyState
    {
        // Variables

        private Bandit bandit;

        // Constructors

        public BanditIDwellState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = bandit.DwellTime;
        }

        public override void Update()
        {
            base.Update();

            if (stateTimer <= 0)
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
