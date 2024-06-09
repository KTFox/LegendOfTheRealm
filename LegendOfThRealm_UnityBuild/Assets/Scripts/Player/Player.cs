using System.Collections;
using UnityEngine;
using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
{
    public class Player : Entity
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

        private float rollTimer;

        // Properties

        #region States
        private PlayerStateMachine stateMachine;
        public PlayerIdleState idleState { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        public PlayerJumpState jumpState { get; private set; }
        public PlayerRollState rollState { get; private set; }
        public PlayerAirDashingState airDashingState { get; private set; }
        public PlayerPrimaryAttackState primaryAttackState { get; private set; }
        #endregion

        public Vector2[] AttackMovements => attackMovements;
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public float RollSpeed => rollSpeed;
        public float RollDuration => rollDuration;
        public bool IsBusy { get; private set; } = false;


        // Methods

        protected override void Awake()
        {
            base.Awake();

            stateMachine = new PlayerStateMachine();
            idleState = new PlayerIdleState(this, stateMachine, "Idle");
            moveState = new PlayerMoveState(this, stateMachine, "Move");
            jumpState = new PlayerJumpState(this, stateMachine, "Jump");
            rollState = new PlayerRollState(this, stateMachine, "Roll");
            airDashingState = new PlayerAirDashingState(this, stateMachine, "AirDashing");
            primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        }

        protected override void Start()
        {
            base.Start();

            stateMachine.Initialize(idleState);
        }

        protected override void Update()
        {
            base.Update();

            stateMachine.CurrentState.Update();
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
            stateMachine.CurrentState.AnimationFinishTrigger();
        }
    }
}
