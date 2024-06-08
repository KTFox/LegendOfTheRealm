using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerStateMachine
    {
        // Variables

        public PlayerState currentState { get; private set; }


        // Methods

        public void Initialize(PlayerState startState)
        {
            currentState = startState;
            currentState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
