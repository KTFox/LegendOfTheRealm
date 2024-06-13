using System.Collections.Generic;
using UnityEngine;

namespace LegendOfTheRealm.Stats
{
    public class ProgressionSO : ScriptableObject
    {
        // Variables

        [SerializeField] private CharacterProgress[] characterProgresses;

        private Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable;

        // Structs

        [System.Serializable]
        private struct CharacterProgress
        {
            public CharacterClass characterClass;
            public StatProgress[] statProgresses;
        }

        [System.Serializable]
        private struct StatProgress
        {
            public Stat Stat;
            public float[] Levels;
        }


        // Methods

        public float GetStat(CharacterClass characterClass, Stat stat, int level)
        {
            BuildLookupTable();

            if (!lookupTable[characterClass].ContainsKey(stat))
            {
                return 0;
            }

            float[] levels = lookupTable[characterClass][stat];

            if (levels.Length == 0)
            {
                return 0;
            }

            if (levels.Length < level)
            {
                return levels[levels.Length - 1];
            }

            return levels[level - 1];
        }

        public int GetLevelLength(CharacterClass characterClass, Stat stat)
        {
            BuildLookupTable();

            float[] levels = lookupTable[characterClass][stat];

            return levels.Length;
        }

        private void BuildLookupTable()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();

            foreach (CharacterProgress characterProgress in characterProgresses)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();

                foreach (StatProgress statProgress in characterProgress.statProgresses)
                {
                    statLookupTable[statProgress.Stat] = statProgress.Levels;
                }

                lookupTable[characterProgress.characterClass] = statLookupTable;
            }
        }
    }
}

