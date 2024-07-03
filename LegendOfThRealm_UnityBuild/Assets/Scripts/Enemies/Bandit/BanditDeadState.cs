namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditDeadState : EnemyState
    {
        // Constructors

        private Bandit bandit;

        public BanditDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            bandit.SetVelocity(0f, 0f);
            stateTimer = 2f;
        }

        public override void Update()
        {
            base.Update();

            if (stateTimer <= 0f)
            {
                bandit.HealthBar.SetActive(false);
            }
        }
    }
}
