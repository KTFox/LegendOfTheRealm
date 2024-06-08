using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerGroundedState : PlayerState
    {
        // Constructors

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
        {

        }


        // Methods

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.K) && player.IsGround)
            {
                stateMachine.ChangeState(player.jumpState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
