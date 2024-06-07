using UnityEngine;

namespace LegendOfTheRealm
{
    public class Player : MonoBehaviour
    {
        // Variables

        #region Components
        public Animator animator {  get; private set; }
        #endregion

        #region States
        private PlayerStateMachine stateMachine;
        public PlayerIdleState idleState { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        #endregion


        // Methods

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            stateMachine = new PlayerStateMachine();

            idleState = new PlayerIdleState(this, stateMachine, "Idle");
            moveState = new PlayerMoveState(this, stateMachine, "Move");
        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            stateMachine.currentState.Update();
        }
    }
}
