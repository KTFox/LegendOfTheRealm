using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class SpinSword : MonoBehaviour
    {
        // Variables

        private Rigidbody2D rb;
        private CircleCollider2D collider2;
        private Animator animator;
        private Player player;


        // Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            collider2 = GetComponent<CircleCollider2D>();
            animator = GetComponentInChildren<Animator>();
        }

        public void Setup(Vector2 direction, float gravityScale)
        {
            rb.velocity = direction;
            rb.gravityScale = gravityScale;
        }
    }
}
