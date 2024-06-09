using UnityEngine;

namespace LegendOfTheRealm.Players
{
    public class PlayerAnimationTriggers : MonoBehaviour
    {
        private void AnimationTrigger()
        {
            GetComponentInParent<Player>().AnimationTrigger();
        }
    }
}
