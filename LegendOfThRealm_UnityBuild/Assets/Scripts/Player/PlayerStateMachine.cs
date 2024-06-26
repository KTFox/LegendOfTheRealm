namespace LegendOfTheRealm.Players
{
    public class PlayerStateMachine
    {
        // Properties

        public PlayerState CurrentState { get; private set; }


        // Methods

        public void Initialize(PlayerState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
