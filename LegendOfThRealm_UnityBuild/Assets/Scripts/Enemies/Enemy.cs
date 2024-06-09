using UnityEngine;

namespace LegendOfTheRealm.Enemies
{
    public class Enemy : MonoBehaviour
    {
        // Properties

        public Rigidbody2D Rb { get; private set; }
        public Animator Animator { get; private set; }

        public EnemyStateMachine StateMachine { get; private set; }


        // Methods

        private void Awake()
        {
            StateMachine = new EnemyStateMachine();
        }

        private void Update()
        {
            StateMachine.CurrentState.Update();
        }
    }
}
