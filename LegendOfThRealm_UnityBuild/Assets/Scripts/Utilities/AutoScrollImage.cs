using UnityEngine;

namespace LegendOfTheRealm.Utilities
{
    public class AutoScrollImage : MonoBehaviour
    {
        // Variables

        [SerializeField] private Vector2 parallaxEffect;

        private Material material;


        // Methods

        private void Awake()
        {
            material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            material.mainTextureOffset += parallaxEffect * Time.deltaTime;
        }
    }
}
