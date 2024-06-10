namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditAttackState : BanditBattleState
    {
        // Constructors

        public BanditAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            isAttacking = true;
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

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            isAttacking = false;
        }
    }
}
