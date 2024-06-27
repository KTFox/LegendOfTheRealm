using UnityEngine;
using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using LegendOfTheRealm.Stats;

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

        private void OpenCounterAttackWindow()
        {
            enemy.OpenCounterAttackWindow();
        }

        private void CloseCounterAttackWindow()
        {
            enemy.CloseCounterAttackWindow();
        }

        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.AttackCheck.position, enemy.AttackCheckRadius);

            foreach (Collider2D collider in colliders)
            {
                Player player = collider.GetComponent<Player>();
                if (player != null)
                {
                    Health playerHealth = collider.GetComponent<Health>();
                    if (!playerHealth.IsDead)
                    {
                        playerHealth.TakeDamage(GetFinalDamage(enemy.BaseStat, player.BaseStat));
                    }
                }
            }
        }

        private float GetFinalDamage(BaseStat attackerStat, BaseStat defenderStat)
        {
            float attackerPhysicalDamage = attackerStat.GetValueOfStat(Stat.PhysicalDamage);
            float defenderDefence = defenderStat.GetValueOfStat(Stat.PhysicalDefence);

            return Mathf.Max(1, attackerPhysicalDamage - defenderDefence);
        }
    }
}
