namespace LegendOfTheRealm.Enemies.Bandits
{
    public class Bandit : Enemy
    {
        // Properties

        #region States
        public BanditIdleState IdleState { get; private set; }
        public BanditMoveState MoveState { get; private set; }
        #endregion


        // Methods

        protected override void Awake()
        {
            base.Awake();

            IdleState = new BanditIdleState(this, StateMachine, "Idle");
            MoveState = new BanditMoveState(this, StateMachine, "Move");
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
