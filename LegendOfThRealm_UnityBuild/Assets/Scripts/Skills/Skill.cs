using LegendOfTheRealm.Players;
using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class Skill : MonoBehaviour
    {
        // Variables

        [SerializeField] protected float cooldown;

        protected Player player;
        protected float cooldownTimer;


        // Methods

        private void Start()
        {
            player = FindObjectOfType<Player>();
        }

        protected virtual void Update()
        {
            cooldownTimer -= Time.deltaTime;
        }

        public virtual bool TryUseSkill()
        {
            if (cooldownTimer <= 0f)
            {
                cooldownTimer = cooldown;
                UseSkill();

                return true;
            }

            return false;
        }

        protected virtual void UseSkill()
        {

        }
    }
}
