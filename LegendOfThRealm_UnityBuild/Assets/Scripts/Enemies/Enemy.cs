using UnityEngine;
using UnityEngine.UI;

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

        [Header("Player detect info")]
        [SerializeField] private Vector2 boxOrigin;
        [SerializeField] private Vector2 boxSize;
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private Color gizmoIdleColor;
        [SerializeField] private Color gimoDetectedColor;

        [Header("Battle info")]
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown;
        [SerializeField] private float suspiciousTime;

        [Header("UI")]
        [SerializeField] private GameObject healthBar;

        protected bool canBeStunned;

        // Properties

        #region States
        public EnemyStateMachine StateMachine { get; private set; }
        #endregion

        public float PatrolSpeed => patrolSpeed;
        public float DwellTime => dwellTime;
        public PatrolPoints PatrolPoints => patrolPoints;
        public float MinDistanceToWaypoint => minDistanceToWaypoint;
        public GameObject Target { get; private set; }
        public bool IsPlayerDetected => Target != null;
        public float ChaseSpeed => chaseSpeed;
        public float AttackRange => attackRange;
        public float AttackCooldown => attackCooldown;
        public float SuspiciousTime => suspiciousTime;
        public GameObject HealthBar => healthBar;


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

            PerformDetected();
        }

        private void PerformDetected()
        {
            Collider2D collider = Physics2D.OverlapBox(boxOrigin, boxSize, 0f, playerLayerMask);

            if (collider != null)
            {
                Target = collider.gameObject;
            }
            else
            {
                Target = null;
            }
        }

        public virtual bool TryToBeStunned()
        {
            if (canBeStunned)
            {
                CloseCounterAttackWindow();

                return true;
            }

            return false;
        }

        public virtual void OpenCounterAttackWindow()
        {
            canBeStunned = true;
        }

        public virtual void CloseCounterAttackWindow()
        {
            canBeStunned = false;
        }

        public void AnimationFinishTrigger()
        {
            StateMachine.CurrentState.AnimationFinishTrigger();
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            // Draw patrol paths
            Gizmos.color = Color.green;
            for (int i = 0; i < patrolPoints.Points.Length; i++)
            {
                Gizmos.DrawWireSphere(patrolPoints.Points[i], minDistanceToWaypoint);
                Gizmos.DrawLine(patrolPoints.Points[i], patrolPoints.Points[patrolPoints.GetNextIndexOf(i)]);
            }

            // Draw detected area
            Gizmos.color = gizmoIdleColor;
            if (IsPlayerDetected)
            {
                Gizmos.color = gimoDetectedColor;
            }
            Gizmos.DrawCube(boxOrigin, boxSize);

            // Draw attack range
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
