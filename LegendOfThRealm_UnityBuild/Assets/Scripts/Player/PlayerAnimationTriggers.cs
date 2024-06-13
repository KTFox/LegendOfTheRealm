using LegendOfTheRealm.Enemies;
using LegendOfTheRealm.Managers;
using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerAnimationTriggers : MonoBehaviour
    {
        // Variables

        private Player player;


        // Methods

        private void Awake()
        {
            player = GetComponentInParent<Player>();
        }

        private void AnimationTrigger()
        {
            player.AnimationFinishTrigger();
        }

        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Enemy>() != null)
                {
                    collider.GetComponent<Enemy>().TakeDamage();
                }
            }
        }
    }
}
