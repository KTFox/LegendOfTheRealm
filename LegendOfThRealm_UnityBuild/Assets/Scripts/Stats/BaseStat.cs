using System;
using UnityEngine;

namespace LegendOfTheRealm.Stats
{
    public class BaseStat : MonoBehaviour
    {
        // Variables

        [SerializeField] private ProgressionSO progressionSO;
        [SerializeField] private CharacterClass characterClass;
        [Range(1, 3)]
        [SerializeField] private int startLevel = 1;
        [SerializeField] private bool shouldUseModifier;

        private Experience _experience;

        private int currentLevel;

        // Properties

        public int CurrentLevel => currentLevel;
        public float ExperienceToLevelUp => progressionSO.GetStat(characterClass, Stat.ExperienceToLevelUp, CurrentLevel);


        // Methods

        private void Awake()
        {
            _experience = GetComponent<Experience>();
        }

        public float GetValueOfStat(Stat stat)
        {
            return GetBaseStat(stat);
            //return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * (1 + GetPercentageModifier(stat) / 100);
        }

        private float GetBaseStat(Stat stat)
        {
            return progressionSO.GetStat(characterClass, stat, currentLevel);
        }

        //private float GetAdditiveModifier(Stat stat)
        //{
        //    if (!_shouldUseModifier)
        //    {
        //        return 0;
        //    }

        //    float total = 0;

        //    foreach (IModifierProvider modifierProvider in GetComponents<IModifierProvider>())
        //    {
        //        foreach (float additiveModifier in modifierProvider.GetAdditiveModifiers(stat))
        //        {
        //            total += additiveModifier;
        //        }
        //    }

        //    return total;
        //}

        //private float GetPercentageModifier(Stat stat)
        //{
        //    if (!_shouldUseModifier)
        //    {
        //        return 0;
        //    }

        //    float total = 0;

        //    foreach (IModifierProvider modifierProvider in GetComponents<IModifierProvider>())
        //    {
        //        foreach (float percentageModifier in modifierProvider.GetPercentageModifiers(stat))
        //        {
        //            total += percentageModifier;
        //        }
        //    }

        //    return total;
        //}

        private int GetCurrentLevel()
        {
            var experience = GetComponent<Experience>();

            if (experience == null)
            {
                return startLevel;
            }

            float currentXP = experience.ExperiencePoint;
            int penultimateLevel = progressionSO.GetLevelLength(characterClass, Stat.ExperienceToLevelUp);

            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUp = progressionSO.GetStat(characterClass, Stat.ExperienceToLevelUp, level);

                if (XPToLevelUp > currentXP)
                {
                    return level;
                }
            }

            return penultimateLevel + 1;
        }
    }
}
