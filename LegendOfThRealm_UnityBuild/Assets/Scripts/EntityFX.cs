using Cinemachine;
using DG.Tweening;
using LegendOfTheRealm.Players;
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

        [Header("Camera shake FX")]
        [SerializeField] private float shakeMultiplier;
        [SerializeField] private Vector2 shakePower;

        private Player player;
        private Material originalMat;
        private SpriteRenderer spriteRenderer;
        private CinemachineImpulseSource impulseSource;


        // Methods

        private void Awake()
        {
            player = FindAnyObjectByType<Player>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            originalMat = spriteRenderer.material;
            impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        public void PlayCameraShakeFX()
        {
            impulseSource.m_DefaultVelocity = new Vector3(player.FacingDir * shakePower.x, shakePower.y) * shakeMultiplier;
            impulseSource.GenerateImpulse();
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
