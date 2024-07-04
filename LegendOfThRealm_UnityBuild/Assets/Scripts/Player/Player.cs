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
        private SkillManager skillManager;

        // Properties

        #region States
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerRollState RollState { get; private set; }
        public PlayerAirDashingState AirDashingState { get; private set; }
        public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }
        public PlayerCounterAttackState CounterAttackState { get; private set; }
        public PlayerHeavyAttackState HeavyAttackState { get; private set; }
        public PlayerHealingState HealingState { get; private set; }
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
            skillManager = SkillManager.Instance;

            #region Player states caching
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, "Idle");
            MoveState = new PlayerMoveState(this, StateMachine, "Move");
            JumpState = new PlayerJumpState(this, StateMachine, "Jump");
            RollState = new PlayerRollState(this, StateMachine, "Roll");
            AirDashingState = new PlayerAirDashingState(this, StateMachine, "AirDashing");
            PrimaryAttackState = new PlayerPrimaryAttackState(this, StateMachine, "Attack");
            CounterAttackState = new PlayerCounterAttackState(this, StateMachine, "CounterAttack");
            HeavyAttackState = new PlayerHeavyAttackState(this, StateMachine, "HeavyAttack");
            HealingState = new PlayerHealingState(this, StateMachine, "Heal");
            DeathState = new PlayerDeathState(this, StateMachine, "Die");
            #endregion
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);

            InputManager.Instance.OnJump += InputManager_OnJump;
            InputManager.Instance.OnDash += InputManager_OnDash;
            InputManager.Instance.OnAttack += InputManager_OnAttack;
            InputManager.Instance.OnCounterAttack += InputManager_OnCounterAttack;
            InputManager.Instance.OnUseItem1 += InputManager_OnUseItem1;
            InputManager.Instance.OnUseItem2 += InputManager_OnUseItem2;
            InputManager.Instance.OnUseItem3 += InputManager_OnUseItem3;
            InputManager.Instance.OnHeavyAttack += InputManager_OnHeavyAttack;
        }

        protected override void Update()
        {
            base.Update();

            StateMachine.CurrentState.Update();
        }

        private void InputManager_OnJump()
        {
            StateMachine.CurrentState.OnJump();
        }

        private void InputManager_OnDash()
        {
            skillManager.DashSkill.Use();
        }

        private void InputManager_OnAttack()
        {
            StateMachine.CurrentState.OnAttack();
        }

        private void InputManager_OnCounterAttack()
        {
            StateMachine.CurrentState.OnCounterAttack();
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

        private void InputManager_OnHeavyAttack()
        {
            skillManager.HeavyAttackSkill.Use();
        }

        public override void Die()
        {
            base.Die();

            StateMachine.ChangeState(DeathState);
        }

        public IEnumerator BusyFor(float seconds)
        {
            IsBusy = true;

            yield return new WaitForSeconds(seconds);

            IsBusy = false;
        }

        public void AnimationFinishTrigger()
        {
            StateMachine.CurrentState.AnimationFinishTrigger();
        }
    }
}
