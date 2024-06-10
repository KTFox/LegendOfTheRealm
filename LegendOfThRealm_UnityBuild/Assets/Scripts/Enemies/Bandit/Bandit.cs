using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class Bandit : Enemy
    {
        // Properties

        #region States
        public BanditIDwellState DwellState { get; private set; }
        public BanditWalkAroundState WalkAroundState { get; private set; }
        public ChaseState ChaseState { get; private set; }
        #endregion


        // Methods

        protected override void Awake()
        {
            base.Awake();

            DwellState = new BanditIDwellState(this, StateMachine, "Idle");
            WalkAroundState = new BanditWalkAroundState(this, StateMachine, "Move");
            ChaseState = new ChaseState(this, StateMachine, "Move");
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
