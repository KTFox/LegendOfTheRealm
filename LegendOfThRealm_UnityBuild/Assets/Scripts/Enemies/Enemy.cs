namespace LegendOfTheRealm.Enemies
{
    public class Enemy : Entity
    {
        // Properties

        #region States
        public EnemyStateMachine StateMachine { get; private set; }
        #endregion


        // Methods

        protected override void Awake()
        {
            base.Awake();

            StateMachine = new EnemyStateMachine();
        }

        protected override void Update()
        {
            base.Update();

            StateMachine.CurrentState.Update();
        }
    }
}
