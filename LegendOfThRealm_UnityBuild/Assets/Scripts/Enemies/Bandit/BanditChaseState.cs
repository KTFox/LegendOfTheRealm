using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditChaseState : BanditBattleState
    {
        // Constructors

        public BanditChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
                Vector2 moveDir = (bandit.Target.transform.position - bandit.transform.position).normalized;
                bandit.SetVelocity(moveDir.x * bandit.ChaseSpeed, 0f);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
