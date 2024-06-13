using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class SpinSword : MonoBehaviour
    {
        // Variables

        private Rigidbody2D rb;
        private Animator animator;
        private Player player;


        // Methods

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
        }

        public void Setup(Vector2 direction)
        {
            rb.velocity = direction;
        }
    }
}
