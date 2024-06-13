using LegendOfTheRealm.Managers;
using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerState
    {
        // Variables

        protected InputManager inputManger;
        protected PlayerStateMachine stateMachine;
        protected Player player;
        protected Rigidbody2D playerRb;

        private string animBoolName;

        protected float stateTimer;
        protected bool triggerCalled;

        // Constructors

        public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        {
            inputManger = InputManager.Instance;

            this.player = player;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }


        // Methods

        public virtual void Enter()
        {
            player.Animator.SetBool(animBoolName, true);
            playerRb = player.Rb;
            triggerCalled = false;
        }

        public virtual void Update()
        {
            player.Animator.SetFloat("yVelocity", playerRb.velocity.y);
            stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            player.Animator.SetBool(animBoolName, false);
        }

        public virtual void OnJump() { }

        public virtual void AnimationFinishTrigger()
        {
            triggerCalled = true;
        }
    }
}
