namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditMoveState : EnemyState
    {
        // Variables

        private Bandit bandit;

        // Constructors

        public BanditMoveState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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

            bandit.SetVelocity(bandit.MoveSpeed * bandit.FacingDir, bandit.Rb.velocity.y);

            if (bandit.IsWallDetected || !bandit.IsGroundDetected)
            {
                bandit.Flip();
                stateMachine.ChangeState(bandit.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
