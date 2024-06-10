using UnityEngine;

namespace LegendOfTheRealm
{
    [System.Serializable]
    public class PatrolPoints
    {
        [Tooltip("Should set y value equal y position of GameObject")]
        public Vector2[] Points;

        public int GetNextIndexOf(int currentIndex)
        {
            if (currentIndex == Points.Length - 1)
            {
                return 0;
            }
            else
            {
                return currentIndex + 1;
            }
        }
    }
}
