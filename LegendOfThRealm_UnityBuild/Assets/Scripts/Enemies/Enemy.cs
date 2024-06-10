using UnityEngine;

namespace LegendOfTheRealm.Enemies
{
    public class Enemy : Entity
    {
        // Variables

        [Header("Patrol info")]
        [SerializeField] private float patrolSpeed;
        [SerializeField] private float dwellTime;
        [SerializeField] private PatrolPoints patrolPoints;
        [SerializeField] private float minDistanceToWaypoint = 0.1f;

        // Properties

        #region States
        public EnemyStateMachine StateMachine { get; private set; }
        #endregion

        public float PatrolSpeed => patrolSpeed;
        public float DwellTime => dwellTime;
        public PatrolPoints PatrolPoints => patrolPoints;
        public float MinDistanceToWaypoint => minDistanceToWaypoint;


        // Methods

        protected override void Awake()
        {
            base.Awake();

            StateMachine = new EnemyStateMachine();
        }

        protected override void Update()
        {
            base.Update();

            StateMachine.CurrentState.Update();
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.color = Color.green;
            for (int i = 0; i < patrolPoints.Points.Length; i++)
            {
                Gizmos.DrawWireSphere(patrolPoints.Points[i], minDistanceToWaypoint);
                Gizmos.DrawLine(patrolPoints.Points[i], patrolPoints.Points[patrolPoints.GetNextIndexOf(i)]);
            }
        }
    }
}
