using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class Bandit : Enemy
    {
        // Variables

        [Header("Move info")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float idleTime;

        // Properties

        #region States
        public BanditIdleState IdleState { get; private set; }
        public BanditMoveState MoveState { get; private set; }
        #endregion

        public float MoveSpeed => moveSpeed;
        public float IdleTime => idleTime;


        // Methods

        protected override void Awake()
        {
            base.Awake();

            IdleState = new BanditIdleState(this, StateMachine, "Idle");
            MoveState = new BanditMoveState(this, StateMachine, "Move");
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(IdleState);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
