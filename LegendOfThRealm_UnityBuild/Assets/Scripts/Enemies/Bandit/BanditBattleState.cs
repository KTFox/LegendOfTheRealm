using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditBattleState : EnemyState
    {
        // Variables

        protected Bandit bandit;
        protected float distanceToTarget;
        protected bool isAttacking;

        // Constructors

        public BanditBattleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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

            if (bandit.Target != null)
            {
                distanceToTarget = Vector2.Distance(bandit.transform.position, bandit.Target.transform.position);
            }

            if (!bandit.IsPlayerDetected && !isAttacking)
            {
                stateMachine.ChangeState(bandit.SuspiciousState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
