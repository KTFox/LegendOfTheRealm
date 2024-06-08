using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerRollState : PlayerState
    {
        // Constructors

        public PlayerRollState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.RollDuration;
        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(player.FacingDir * player.RollSpeed, 0f);

            if (stateTimer < 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            player.SetVelocity(0f, playerRb.velocity.y);
        }
    }
}
