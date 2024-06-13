using System;
using UnityEngine;

namespace LegendOfTheRealm.Stats
{
    public class Experience : MonoBehaviour
    {
        // Variables

        [SerializeField] private float experiencePoints;

        // Properties

        public float ExperiencePoint => experiencePoints;

        // Events

        public event Action OnExperienceGained;


        // Methods

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
            OnExperienceGained?.Invoke();
        }
    }
}
