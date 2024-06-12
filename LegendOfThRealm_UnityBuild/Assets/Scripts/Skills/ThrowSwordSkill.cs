using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class ThrowSwordSkill : Skill
    {
        // Variables

        [SerializeField] private SpinSword swordPrefab;
        [SerializeField] private Vector2 throwDirection;
        [SerializeField] private float swordGravity;


        // Methods

        public void CreateSword()
        {
            SpinSword spinSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
            spinSword.Setup(throwDirection, swordGravity);
        }
    }
}
