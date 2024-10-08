namespace LegendOfTheRealm.Enemies.Bandits
{
    public class Bandit : Enemy
    {
        // Properties

        #region States
        public BanditDwellState DwellState { get; private set; }
        public BanditWalkAroundState WalkAroundState { get; private set; }
        public BanditChaseState ChaseState { get; private set; }
        public BanditAttackState AttackState { get; private set; }
        public BanditAttackCooldownState CooldownState { get; private set; }
        public BanditSuspiciousState SuspiciousState { get; private set; }
        public BanditStunnedState StunnedState { get; private set; }
        public BanditDeadState DeadState { get; private set; }
        #endregion


        // Methods

        protected override void Awake()
        {
            base.Awake();

            #region States caching
            DwellState = new BanditDwellState(this, StateMachine, "Idle");
            WalkAroundState = new BanditWalkAroundState(this, StateMachine, "Move");
            ChaseState = new BanditChaseState(this, StateMachine, "Move");
            AttackState = new BanditAttackState(this, StateMachine, "Attack");
            CooldownState = new BanditAttackCooldownState(this, StateMachine, "Idle");
            SuspiciousState = new BanditSuspiciousState(this, StateMachine, "Idle");
            StunnedState = new BanditStunnedState(this, StateMachine, "Stunned");
            DeadState = new BanditDeadState(this, StateMachine, "Die");
            #endregion
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(WalkAroundState);
        }

        protected override void Update()
        {
            base.Update();
        }

        public override bool TryToBeStunned()
        {
            if (base.TryToBeStunned())
            {
                StateMachine.ChangeState(StunnedState);

                return true;
            }

            return false;
        }

        public override void Die()
        {
            base.Die();

            StateMachine.ChangeState(DeadState);
        }
    }
}
