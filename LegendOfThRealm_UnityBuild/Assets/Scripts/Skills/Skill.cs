using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class Skill : MonoBehaviour
    {
        // Variables

        [SerializeField] protected float cooldown;

        protected float cooldownTimer;


        // Methods

        protected virtual void Update()
        {
            cooldownTimer -= Time.deltaTime;
        }

        public virtual bool CanUseSkill()
        {
            if (cooldownTimer <= 0)
            {
                cooldownTimer = cooldown;
                return true;
            }

            Debug.Log("Skill is on cooldown");
            return false;
        }
    }
}
