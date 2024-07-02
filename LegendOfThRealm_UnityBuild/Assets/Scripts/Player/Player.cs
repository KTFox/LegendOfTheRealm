using System.Collections;
using UnityEngine;
using LegendOfTheRealm.Managers;
using LegendOfTheRealm.Inventories;

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

        private UseableItemStore useableItemStore;

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
        public PlayerDeathState DeathState { get; private set; }
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

            useableItemStore = GetComponent<UseableItemStore>();

            #region Player states caching
            stateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, stateMachine, "Idle");
            MoveState = new PlayerMoveState(this, stateMachine, "Move");
            JumpState = new PlayerJumpState(this, stateMachine, "Jump");
            RollState = new PlayerRollState(this, stateMachine, "Roll");
            AirDashingState = new PlayerAirDashingState(this, stateMachine, "AirDashing");
            PrimaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
            CounterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
            DeathState = new PlayerDeathState(this, stateMachine, "Die");
            #endregion
        }

        protected override void Start()
        {
            base.Start();

            stateMachine.Initialize(IdleState);

            InputManager.Instance.OnJump += InputManager_OnJump;
            InputManager.Instance.OnDash += InputManager_OnDash;
            InputManager.Instance.OnAttack += InputManager_OnAttack;
            InputManager.Instance.OnCounterAttack += InputManager_OnCounterAttack;
            InputManager.Instance.OnUseItem1 += InputManager_OnUseItem1;
            InputManager.Instance.OnUseItem2 += InputManager_OnUseItem2;
            InputManager.Instance.OnUseItem3 += InputManager_OnUseItem3;
        }

        protected override void Update()
        {
            base.Update();

            stateMachine.CurrentState.Update();
        }

        private void InputManager_OnJump()
        {
            stateMachine.CurrentState.OnJump();
        }

        private void InputManager_OnDash()
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

        private void InputManager_OnAttack()
        {
            stateMachine.CurrentState.OnAttack();
        }

        private void InputManager_OnCounterAttack()
        {
            stateMachine.CurrentState.OnCounterAttack();
        }

        private void InputManager_OnUseItem1()
        {
            useableItemStore.UseItemIn(0);
        }

        private void InputManager_OnUseItem2()
        {
            useableItemStore.UseItemIn(1);
        }

        private void InputManager_OnUseItem3()
        {
            useableItemStore.UseItemIn(2);
        }

        public override void Die()
        {
            base.Die();

            stateMachine.ChangeState(DeathState);
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
