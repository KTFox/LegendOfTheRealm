using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm.Enemies
{
    public class EnemyAnimationTrigger : MonoBehaviour
    {
        // Variables

        private Enemy enemy;


        // Methods

        private void Awake()
        {
            enemy = GetComponentInParent<Enemy>();
        }

        private void AnimationTrigger()
        {
            enemy.AnimationFinishTrigger();
        }

        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.AttackCheck.position, enemy.AttackCheckRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Player>() != null)
                {
                    collider.GetComponent<Player>().TakeDamage();
                }
            }
        }

        private void OpenCounterAttackWindow()
        {
            enemy.OpenCounterAttackWindow();
        }

        private void CloseCounterAttackWindow()
        {
            enemy.CloseCounterAttackWindow();
        }
    }
}
