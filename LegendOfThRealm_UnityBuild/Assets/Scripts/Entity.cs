using LegendOfTheRealm.Stats;
using System.Collections;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class Entity : MonoBehaviour
    {
        // Variables

        private const float FREEZE_TIME = 0.1f;

        [Header("Attack info")]
        [SerializeField] protected Transform attackCheck;
        [SerializeField] protected float attackCheckRadius;
        [SerializeField] protected Vector2[] attackMovements;

        [Header("Collision info")]
        [SerializeField] protected Transform groundCheck;
        [SerializeField] protected float groundCheckDistance;
        [SerializeField] protected LayerMask groundLayerMask;
        [SerializeField] protected Transform wallCheck;
        [SerializeField] protected float wallCheckDistance;
        [SerializeField] protected LayerMask wallLayerMask;

        protected bool isFacingRight = true;

        // Properties

        #region Components
        public Rigidbody2D Rb { get; private set; }
        public Animator Animator { get; private set; }
        public EntityFX EntityFX { get; private set; }
        public BaseStat BaseStat { get; private set; }
        #endregion

        public int FacingDir { get; private set; } = 1;
        public virtual bool IsGroundDetected => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);
        public virtual bool IsWallDetected => Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDir, wallCheckDistance, wallLayerMask);
        public Transform AttackCheck => attackCheck;
        public float AttackCheckRadius => attackCheckRadius;
        public Vector2[] AttackMovements => attackMovements;


        // Methods

        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<Animator>();
            EntityFX = GetComponent<EntityFX>();
            BaseStat = GetComponent<BaseStat>();
        }

        protected virtual void Start() { }

        protected virtual void Update() { }

        public virtual void Die() { }

        public void FreezeTime()
        {
            StartCoroutine(nameof(FreezeTimerCoroutine));
        }

        private IEnumerator FreezeTimerCoroutine()
        {
            SetVelocity(0f, 0f);
            Animator.speed = 0f;

            yield return new WaitForSeconds(FREEZE_TIME);

            Animator.speed = 1f;
        }

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            Rb.velocity = new Vector2(xVelocity, yVelocity);
            ControllFlipping(xVelocity);
        }

        public virtual void ControllFlipping(float xInput)
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

        public virtual void Flip()
        {
            FacingDir *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
            Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
        }
    }
}
