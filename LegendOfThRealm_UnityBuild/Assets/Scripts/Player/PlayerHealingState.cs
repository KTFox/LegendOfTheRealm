using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class PlayerHealingState : PlayerGroundedState
    {
        // Variables

        public float healingAmount;


        // Constructor

        public PlayerHealingState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) { }


        // Methods

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            if (triggerCalled)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            player.GetComponent<Health>().Heal(healingAmount);
        }
    }
}
