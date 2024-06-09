using UnityEngine;

namespace LegendOfTheRealm
{
    public class Entity : MonoBehaviour
    {
        // Variables

        [Header("Collision info")]
        [SerializeField] protected Transform groundCheck;
        [SerializeField] protected float groundCheckDistance;
        [SerializeField] protected LayerMask groundLayerMask;

        protected bool isFacingRight = true;

        // Properties

        #region Components
        public Rigidbody2D Rb { get; private set; }
        public Animator Animator { get; private set; }
        #endregion

        public int FacingDir { get; private set; } = 1;
        public virtual bool IsGround => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayerMask);


        // Methods

        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<Animator>();
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {

        }

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            Rb.velocity = new Vector2(xVelocity, yVelocity);
            ControllFlipping(xVelocity);
        }

        protected virtual void ControllFlipping(float xInput)
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

        protected virtual void Flip()
        {
            FacingDir *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        }
    }
}
