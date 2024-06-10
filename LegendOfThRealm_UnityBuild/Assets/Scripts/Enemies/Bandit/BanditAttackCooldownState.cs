namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditAttackCooldownState : BanditBattleState
    {
        // Constructors

        public BanditAttackCooldownState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = bandit.AttackCooldown;
        }

        public override void Update()
        {
            base.Update();

            if (bandit.Target != null)
            {
                bandit.ControllFlipping(bandit.Target.transform.position.x - bandit.transform.position.x);
            }

            if (stateTimer <= 0)
            {
                if (distanceToTarget <= bandit.AttackRange)
                {
                    stateMachine.ChangeState(bandit.AttackState);
                }
                else
                {
                    stateMachine.ChangeState(bandit.ChaseState);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
