using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerRollState : PlayerState
    {
        // Variables

        private float rollDir;

        // Constructors

        public PlayerRollState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.RollDuration;

            rollDir = player.FacingDir;
            if (InputManager.Instance.GetHorizontalInput() != 0)
            {
                rollDir = InputManager.Instance.GetHorizontalInput();
            }
        }

        public override void Update()
        {
            base.Update();

            player.SetVelocity(rollDir * player.RollSpeed, 0f);

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
