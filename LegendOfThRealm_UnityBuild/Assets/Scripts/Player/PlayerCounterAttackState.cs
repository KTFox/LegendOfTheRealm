using LegendOfTheRealm.Enemies;
using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerCounterAttackState : PlayerState
    {
        // Constructor

        public PlayerCounterAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


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
                    if (collider.GetComponent<Enemy>().CanbeStunned())
                    {
                        stateTimer = 10f;
                        player.Animator.SetBool("SuccessCounterAttack", true);
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
