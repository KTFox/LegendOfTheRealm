using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Enemies;
using LegendOfTheRealm.Stats;
using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerCounterAttackState : PlayerState
    {
        // Constructor

        public PlayerCounterAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.CounterAttackDuration;
            player.Animator.SetBool("SuccessCounterAttack", false);
        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(0f, 0f);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Enemy>() != null)
                {
                    if (collider.GetComponent<Enemy>().TryToBeStunned())
                    {
                        stateTimer = 10f;
                        player.Animator.SetBool("SuccessCounterAttack", true);

                        float damage = player.BaseStat.GetValueOfStat(Stat.PhysicalDamage);
                        collider.GetComponent<Health>().TakeDamage(damage);

                        player.EntityFX.PlayCameraShakeFX();
                    }
                }
            }

            if (stateTimer <= 0f || triggerCalled)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
