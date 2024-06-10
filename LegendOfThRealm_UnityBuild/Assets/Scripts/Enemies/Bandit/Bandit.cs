using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class Bandit : Enemy
    {
        // Properties

        #region States
        public BanditDwellState DwellState { get; private set; }
        public BanditWalkAroundState WalkAroundState { get; private set; }
        public BanditChaseState ChaseState { get; private set; }
        public BanditAttackState AttackState { get; private set; }
        #endregion


        // Methods

        protected override void Awake()
        {
            base.Awake();

            DwellState = new BanditDwellState(this, StateMachine, "Idle");
            WalkAroundState = new BanditWalkAroundState(this, StateMachine, "Move");
            ChaseState = new BanditChaseState(this, StateMachine, "Move");
            AttackState = new BanditAttackState(this, StateMachine, "Attack");
        }

        protected override void Start()
        {
            base.Start();

            StateMachine.Initialize(WalkAroundState);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
