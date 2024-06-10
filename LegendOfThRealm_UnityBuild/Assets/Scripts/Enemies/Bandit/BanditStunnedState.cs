using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditStunnedState : EnemyState
    {
        // Variables

        private Bandit bandit;

        // Constructors

        public BanditStunnedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            bandit.Rb.velocity = new Vector2(bandit.KnockbackDirection.x * -bandit.FacingDir, bandit.KnockbackDirection.y);
        }

        public override void Update()
        {
            base.Update();

            if (triggerCalled)
            {
                stateMachine.ChangeState(bandit.CooldownState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

