using UnityEngine;

namespace LegendOfTheRealm.Enemies
{
    public class EnemyState
    {
        // Variables

        protected EnemyStateMachine stateMachine;
        protected Enemy enemy;

        private string animBoolName;

        protected float stateTimer;
        protected bool triggerCalled;


        // Constructors

        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
        {
            this.enemy = enemy;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }


        // Methods

        public virtual void Enter()
        {
            triggerCalled = false;
            enemy.Animator.SetBool(animBoolName, true);
        }

        public virtual void Update()
        {
            stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            enemy.Animator.SetBool(animBoolName, false);
        }

        public virtual void AnimationFinishTrigger()
        {
            triggerCalled = true;
        }
    }
}
