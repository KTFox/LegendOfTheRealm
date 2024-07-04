using LegendOfTheRealm.Players;
using System.Collections;
using System.Collections.Generic;
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

        protected virtual void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        protected virtual void Update()
        {
            cooldownTimer -= Time.deltaTime;
        }

        public virtual void Use() { }
    }
}
