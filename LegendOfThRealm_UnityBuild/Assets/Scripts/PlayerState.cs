using UnityEngine;

namespace LegendOfTheRealm
{
    public class PlayerState
    {
        // Variables

        protected PlayerStateMachine stateMachine;
        protected Player player;
        protected Rigidbody2D playerRb;

        private string animBoolName;
        protected float xInput;

        // Constructors

        public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }


        // Methods

        public virtual void Enter()
        {
            player.animator.SetBool(animBoolName, true);
            playerRb = player.rb;
        }

        public virtual void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
        }

        public virtual void Exit()
        {
            player.animator.SetBool(animBoolName, false);
        }
    }
}
