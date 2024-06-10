using System.Collections;
using UnityEngine;

namespace LegendOfTheRealm
{
    public class EntityFX : MonoBehaviour
    {
        // Variables

        [Header("Flash FX")]
        [SerializeField] private Material flashMaterial;
        [SerializeField] private float flashDuration = 0.2f;

        private Material originalMat;
        private SpriteRenderer spriteRenderer;


        // Methods

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            originalMat = spriteRenderer.material;
        }

        public void PlayFlashFX()
        {
            StartCoroutine(nameof(FlashFXCoroutine));
        }

        private IEnumerator FlashFXCoroutine()
        {
            spriteRenderer.material = flashMaterial;

            yield return new WaitForSeconds(flashDuration);

            spriteRenderer.material = originalMat;  
        }
    }
}
