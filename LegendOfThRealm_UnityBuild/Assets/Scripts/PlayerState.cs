using UnityEngine;

namespace LegendOfTheRealm
{
    public class PlayerState
    {
        // Variables

        protected PlayerStateMachine stateMachine;
        protected Player player;

        private string animBoolName;

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
        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {
            player.animator.SetBool(animBoolName, false);
        }
    }
}
