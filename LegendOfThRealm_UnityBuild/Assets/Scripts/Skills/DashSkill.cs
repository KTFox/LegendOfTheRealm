namespace LegendOfTheRealm.Skills
{
    public class DashSkill : Skill
    {
        public override void Use()
        {
            base.Use();

            if (cooldownTimer > 0)
            {
                return;
            }

            cooldownTimer = cooldown;

            if (player.IsGroundDetected)
            {
                player.StateMachine.ChangeState(player.RollState);
            }
            else
            {
                player.StateMachine.ChangeState(player.AirDashingState);
            }
        }
    }
}
