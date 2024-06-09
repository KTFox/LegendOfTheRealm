using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerState
    {
        // Variables

        protected PlayerStateMachine stateMachine;
        protected Player player;
        protected Rigidbody2D playerRb;

        private string animBoolName;
        protected float xInput;

        protected float stateTimer;
        protected bool triggerCalled;

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
            triggerCalled = false;
        }

        public virtual void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            player.animator.SetFloat("yVelocity", playerRb.velocity.y);
            stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            player.animator.SetBool(animBoolName, false);
        }

        public virtual void AnimationFinishTrigger()
        {
            triggerCalled = true;
        }
    }
}
