using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditPatrolState : EnemyState
    {
        // Variables

        protected Bandit bandit;

        // Constructors

        public BanditPatrolState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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

            if (bandit.IsPlayerDetected)
            {
                stateMachine.ChangeState(bandit.ChaseState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
