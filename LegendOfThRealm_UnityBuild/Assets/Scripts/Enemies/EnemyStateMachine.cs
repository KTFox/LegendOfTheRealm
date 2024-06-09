namespace LegendOfTheRealm.Enemies
{
    public class EnemyStateMachine
    {
        // Properties

        public EnemyState CurrentState { get; private set; }


        // Methods

        public void Initialize(EnemyState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(EnemyState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
