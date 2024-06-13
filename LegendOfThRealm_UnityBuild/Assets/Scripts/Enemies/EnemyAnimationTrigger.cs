using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using LegendOfTheRealm.Stats;
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
                    float damage = enemy.BaseStat.GetValueOfStat(Stat.PhysicalDamage);
                    collider.GetComponent<Health>().TakeDamage(10f);

                    Debug.Log($"{collider.gameObject.name} take {damage} damage!!!");
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
