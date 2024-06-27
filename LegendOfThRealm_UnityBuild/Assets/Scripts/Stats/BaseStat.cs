using LegendOfTheRealm.Utilities;
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

        private Experience experience;

        private LazyValue<int> currentLevel;

        // Properties

        public int CurrentLevel => currentLevel.Value;
        public float EXPProgression => CurrentEXPAchieved / EXPRequiredForNextLevel;
        public float EXPRequiredForNextLevel
        {
            get
            {
                float totalEXPToReachCurrentLevel = progressionSO.GetStat(characterClass, Stat.TotalEXPToReachLevel, currentLevel.Value);
                float totalEXPToReachNextLevel = progressionSO.GetStat(characterClass, Stat.TotalEXPToReachLevel, currentLevel.Value + 1);

                return totalEXPToReachNextLevel - totalEXPToReachCurrentLevel;
            }
        }
        public float CurrentEXPAchieved
        {
            get
            {
                float currentEXP = experience.ExperiencePoint;
                float totalEXPToReachCurrentLevel = progressionSO.GetStat(characterClass, Stat.TotalEXPToReachLevel, currentLevel.Value);

                return currentEXP - totalEXPToReachCurrentLevel;
            }
        }


        // Methods

        private void Awake()
        {
            experience = GetComponent<Experience>();
            currentLevel = new LazyValue<int>(GetInitialLevel);
        }

        private int GetInitialLevel()
        {
            return startLevel;
        }

        private void OnEnable()
        {
            if (experience != null)
            {
                experience.OnExperienceGained += Experience_OnExperienceGained;
            }
        }

        private void OnDisable()
        {
            if (experience != null)
            {
                experience.OnExperienceGained -= Experience_OnExperienceGained;
            }
        }

        private void Experience_OnExperienceGained()
        {
            if (currentLevel.Value < GetCurrentLevel())
            {
                currentLevel.Value = GetCurrentLevel();
            }
        }

        private int GetCurrentLevel()
        {
            Experience experience = GetComponent<Experience>();

            if (experience == null)
            {
                return startLevel;
            }

            float currentXP = experience.ExperiencePoint;
            int penultimateLevel = progressionSO.GetLevelLength(characterClass, Stat.TotalEXPToReachLevel);

            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUp = progressionSO.GetStat(characterClass, Stat.TotalEXPToReachLevel, level + 1);

                if (XPToLevelUp > currentXP)
                {
                    return level;
                }
            }

            return penultimateLevel;
        }

        public float GetValueOfStat(Stat stat)
        {
            return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * (1 + GetPercentageModifier(stat) / 100);
        }

        private float GetBaseStat(Stat stat)
        {
            return progressionSO.GetStat(characterClass, stat, CurrentLevel);
        }

        private float GetAdditiveModifier(Stat stat)
        {
            if (!shouldUseModifier)
            {
                return 0;
            }

            float total = 0;

            foreach (IModifierProvider modifierProvider in GetComponents<IModifierProvider>())
            {
                foreach (float additiveModifier in modifierProvider.GetAdditiveModifiers(stat))
                {
                    total += additiveModifier;
                }
            }

            return total;
        }

        private float GetPercentageModifier(Stat stat)
        {
            if (!shouldUseModifier)
            {
                return 0;
            }

            float total = 0;

            foreach (IModifierProvider modifierProvider in GetComponents<IModifierProvider>())
            {
                foreach (float percentageModifier in modifierProvider.GetPercentageModifiers(stat))
                {
                    total += percentageModifier;
                }
            }

            return total;
        }
    }
}
