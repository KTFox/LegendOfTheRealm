using UnityEngine;

namespace LegendOfTheRealm.Enemies
{
    public class EnemyAnimationTrigger : MonoBehaviour
    {
        private void AnimationTrigger()
        {
            GetComponentInParent<Enemy>().AnimationFinishTrigger();
        }
    }
}
