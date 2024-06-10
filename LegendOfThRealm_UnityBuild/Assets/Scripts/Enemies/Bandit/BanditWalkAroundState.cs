using UnityEngine;

namespace LegendOfTheRealm.Enemies.Bandits
{
    public class BanditWalkAroundState : EnemyState
    {
        // Variables

        private Bandit bandit;
        private PatrolPoints patrolPoints;
        private int currentWaypointIndex;

        // Constructors

        public BanditWalkAroundState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
        {
            bandit = enemy as Bandit;
        }


        // Methods

        public override void Enter()
        {
            base.Enter();

            patrolPoints = bandit.PatrolPoints;
        }

        public override void Update()
        {
            base.Update();

            Vector2 moveDir = (patrolPoints.Points[currentWaypointIndex] - (Vector2)bandit.transform.position).normalized;
            bandit.SetVelocity(bandit.PatrolSpeed * moveDir.x, bandit.PatrolSpeed * moveDir.y);

            float distanceToWaypoint = Vector2.Distance(patrolPoints.Points[currentWaypointIndex], bandit.transform.position);
            if (distanceToWaypoint <= bandit.MinDistanceToWaypoint)
            {
                currentWaypointIndex = patrolPoints.GetNextIndexOf(currentWaypointIndex);
                stateMachine.ChangeState(bandit.DwellState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
