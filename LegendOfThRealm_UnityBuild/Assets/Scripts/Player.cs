using UnityEngine;

namespace LegendOfTheRealm
{
    public class Player : MonoBehaviour
    {
        // Variables

        [Header("Move info")]
        [SerializeField] private float moveSpeed = 3f;

        #region Components
        public Rigidbody2D rb { get; private set; }
        public Animator animator { get; private set; }
        #endregion

        #region States
        private PlayerStateMachine stateMachine;
        public PlayerIdleState idleState { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        #endregion

        // Properties

        public float MoveSpeed => moveSpeed;


        // Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
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

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            rb.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}
