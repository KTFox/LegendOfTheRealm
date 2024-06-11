using System.Collections;
using UnityEngine;
using LegendOfTheRealm.Managers;

namespace LegendOfTheRealm.Players
{
    public class Player : Entity
    {
        // Variables

        [Header("Move info")]
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float jumpForce = 7f;

        [Header("Dash info")]
        [SerializeField] private float rollSpeed = 8f;
        [SerializeField] private float rollDuration = 0.3f;

        [Header("Attack details")]
        [SerializeField] private float counterAttackDuration = 0.2f;

        // Properties

        #region States
        private PlayerStateMachine stateMachine;
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerRollState RollState { get; private set; }
        public PlayerAirDashingState AirDashingState { get; private set; }
        public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }
        public PlayerCounterAttackState CounterAttackState { get; private set; }
        #endregion

        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public float RollSpeed => rollSpeed;
        public float RollDuration => rollDuration;
        public float CounterAttackDuration => counterAttackDuration;
        public bool IsBusy { get; private set; } = false;


        // Methods

        protected override void Awake()
        {
            base.Awake();

            stateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, stateMachine, "Idle");
            MoveState = new PlayerMoveState(this, stateMachine, "Move");
            JumpState = new PlayerJumpState(this, stateMachine, "Jump");
            RollState = new PlayerRollState(this, stateMachine, "Roll");
            AirDashingState = new PlayerAirDashingState(this, stateMachine, "AirDashing");
            PrimaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
            CounterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        }

        protected override void Start()
        {
            base.Start();

            stateMachine.Initialize(IdleState);
        }

        protected override void Update()
        {
            base.Update();

            stateMachine.CurrentState.Update();
            CheckForDashInput();
        }

        private void CheckForDashInput()
        {
            if (InputManager.Instance.IsLKeyDown() && SkillManager.Instance.DashSkill.TryUseSkill())
            {
                if (IsGroundDetected)
                {
                    stateMachine.ChangeState(RollState);
                }
                else
                {
                    stateMachine.ChangeState(AirDashingState);
                }
            }
        }

        public IEnumerator BusyFor(float seconds)
        {
            IsBusy = true;

            yield return new WaitForSeconds(seconds);

            IsBusy = false;
        }

        public void AnimationFinishTrigger()
        {
            stateMachine.CurrentState.AnimationFinishTrigger();
        }
    }
}
