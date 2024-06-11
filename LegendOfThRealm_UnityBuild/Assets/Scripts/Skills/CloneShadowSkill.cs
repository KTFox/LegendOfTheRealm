using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class CloneShadowSkill : Skill
    {
        // Variables

        [SerializeField] private PlayerClone clonePrefab;
        [SerializeField] private bool canAttack;


        // Methods

        public void CreateClone(Vector2 position)
        {
            PlayerClone clone = Instantiate(clonePrefab);
            clone.SetupClone(position, canAttack);
        }
    }
}
