using System.Collections;
using UnityEngine;
using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
{
    public class Player : MonoBehaviour
    {
        // Variables

        [Header("Attack details")]
        [SerializeField] private Vector2[] attackMovements;

        [Header("Move info")]
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float jumpForce = 7f;

        [Header("Dash info")]
        [SerializeField] private float rollCooldown = 0.8f;
        [SerializeField] private float rollSpeed = 8f;
        [SerializeField] private float rollDuration = 0.3f;

        [Header("Collision info")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckDistance;
        [SerializeField] private LayerMask groundLayerMask;

        private bool isFacingRight = true;
        private float rollTimer;

        // Properties

        #region Components
        public Rigidbody2D rb { get; private set; }
        public Animator animator { get; private set; }
        #endregion

        #region States
        private PlayerStateMachine stateMachine;
        public PlayerIdleState idleState { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        public PlayerJumpState jumpState { get; private set; }
        public PlayerRollState rollState { get; private set; }
        public PlayerAirDashingState airDashingState { get; private set; }
        public PlayerPrimaryAttackState primaryAttackState { get; private set; }
        #endregion

        public int FacingDir { get; private set; } = 1;
        public Vector2[] AttackMovements => attackMovements;
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public float RollSpeed => rollSpeed;
        public float RollDuration => rollDuration;
        public bool IsGround => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);
        public bool IsBusy { get; private set; } = false;


        // Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();

            stateMachine = new PlayerStateMachine();
            idleState = new PlayerIdleState(this, stateMachine, "Idle");
            moveState = new PlayerMoveState(this, stateMachine, "Move");
            jumpState = new PlayerJumpState(this, stateMachine, "Jump");
            rollState = new PlayerRollState(this, stateMachine, "Roll");
            airDashingState = new PlayerAirDashingState(this, stateMachine, "AirDashing");
            primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            stateMachine.currentState.Update();
            CheckForDashInput();
        }

        private void CheckForDashInput()
        {
            rollTimer -= Time.deltaTime;

            if (InputManager.Instance.IsLKeyDown() && rollTimer < 0)
            {
                rollTimer = rollCooldown;

                if (IsGround)
                {
                    stateMachine.ChangeState(rollState);
                }
                else
                {
                    stateMachine.ChangeState(airDashingState);
                }
            }
        }

        public IEnumerator BusyFor(float seconds)
        {
            IsBusy = true;

            yield return new WaitForSeconds(seconds);

            IsBusy = false;
        }

        public void AnimationTrigger()
        {
            stateMachine.currentState.AnimationFinishTrigger();
        }

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            rb.velocity = new Vector2(xVelocity, yVelocity);
            ControllFlipping(xVelocity);
        }

        private void ControllFlipping(float xInput)
        {
            if (xInput > 0.01f && !isFacingRight)
            {
                Flip();
            }
            else if (xInput < -0.01f && isFacingRight)
            {
                Flip();
            }
        }

        private void Flip()
        {
            FacingDir *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        }
    }
}
