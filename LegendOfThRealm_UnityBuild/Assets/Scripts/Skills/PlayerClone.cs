using DG.Tweening;
using LegendOfTheRealm.Attributes;
using LegendOfTheRealm.Enemies;
using System.Collections;
using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class PlayerClone : MonoBehaviour
    {
        // Variables

        [SerializeField] private float fadeDuration;
        [SerializeField] private float attackRange;
        [SerializeField] private Transform attackCheck;
        [SerializeField] private float attackCheckRadius;

        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private bool isDeath;


        // Methods

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        public void SetupClone(Vector2 position, bool canAttack)
        {
            transform.position = position;
            FaceToClosetTarget();

            if (canAttack)
            {
                animator.SetInteger("AttackNumber", Random.Range(1, 3));
            }
        }

        private void FaceToClosetTarget()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

            float closetDistance = Mathf.Infinity;
            Transform closetEnemy = null;

            foreach (Collider2D hit in hits)
            {
                if (hit.GetComponent<Enemy>() != null)
                {
                    float distanceToHit = Vector2.Distance(transform.position, hit.transform.position);
                    if (distanceToHit < closetDistance)
                    {
                        closetDistance = distanceToHit;
                        closetEnemy = hit.transform;
                    }
                }
            }

            if (closetEnemy != null)
            {
                if (closetEnemy.position.x < transform.position.x)
                {
                    transform.Rotate(0, 180, 0);
                }
            }
        }

        private void AnimationTrigger()
        {
            StartCoroutine(nameof(FadeCoroutine));
        }

        private IEnumerator FadeCoroutine()
        {
            Tween fadeTween = spriteRenderer.DOFade(0f, fadeDuration);

            yield return fadeTween.WaitForCompletion();

            fadeTween.Kill();
            Destroy(gameObject);

        }

        private void AttackTrigger()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);

            foreach (var hit in hits)
            {
                if (hit.GetComponent<Enemy>() != null)
                {
                    hit.GetComponent<Health>().TakeDamage(gameObject, 10f);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
