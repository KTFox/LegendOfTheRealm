using UnityEngine;
using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Enemies;
using LegendOfTheRealm.Stats;

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

        private void FreezeTime()
        {
            player.FreezeTime();
        }

        private void AttackTrigger()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);

            foreach (Collider2D collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Health enemyHealth = enemy.GetComponent<Health>();
                    if (!enemyHealth.IsDead)
                    {
                        enemyHealth.TakeDamage(gameObject, GetFinalPhysicalDamageReceived(player.BaseStat, enemy.BaseStat));

                        enemy.FreezeTime();
                        player.EntityFX.PlayCameraShakeFX();
                    }
                }
            }
        }

        private float GetFinalPhysicalDamageReceived(BaseStat attackerStat, BaseStat defenderStat)
        {
            float attackerPhysicalDamage = attackerStat.GetValueOfStat(Stat.PhysicalDamage);

            bool isCriticalHit = Random.value < attackerStat.GetValueOfStat(Stat.CriticalChance) / 100;
            if (isCriticalHit)
            {
                attackerPhysicalDamage += attackerPhysicalDamage * attackerStat.GetValueOfStat(Stat.CriticalBonus) / 100;
                Debug.Log("Critical damage");
            }

            float defenderDefence = defenderStat.GetValueOfStat(Stat.PhysicalDefence);

            return Mathf.Max(1, attackerPhysicalDamage - defenderDefence);
        }
    }
}
