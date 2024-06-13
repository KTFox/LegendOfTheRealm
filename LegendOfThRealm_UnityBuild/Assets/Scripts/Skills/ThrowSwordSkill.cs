using LegendOfTheRealm.Managers;
using UnityEngine;

namespace LegendOfTheRealm.Skills
{
    public class ThrowSwordSkill : Skill
    {
        // Variables

        [SerializeField] private SpinSword swordPrefab;
        [SerializeField] private float swordGravity;

        [Header("Aiming Dots info")]
        [SerializeField] private int numberOfDots;
        [SerializeField] private float spaceBetweenDots;
        [SerializeField] private GameObject dotPrefab;
        [SerializeField] private Transform dotsParent;

        private Vector2 finalDirection;
        private GameObject[] dots;


        // Methods

        protected override void Start()
        {
            base.Start();

            GenerateAimingDots();
        }

        protected override void Update()
        {
            base.Update();

            if (InputManager.Instance.IsRightMouseButtonUp())
            {
                finalDirection = new Vector2(GetAimDirection().x, GetAimDirection().y);
            }

            if (InputManager.Instance.IsHoldRightMouseButton())
            {
                for (int i = 0; i < numberOfDots; i++)
                {
                    dots[i].transform.position = GetDotPosition(i * spaceBetweenDots);
                }
            }
        }

        private void GenerateAimingDots()
        {
            dots = new GameObject[numberOfDots];
            for (int i = 0; i < numberOfDots; i++)
            {
                dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
                dots[i].SetActive(false);
            }
        }

        public void CreateSword()
        {
            SpinSword spinSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
            spinSword.Setup(finalDirection);

            SetActiveAimingDots(false);
        }

        public void SetActiveAimingDots(bool isActive)
        {
            for (int i = 0; i < numberOfDots; i++)
            {
                dots[i].SetActive(isActive);
            }
        }

        private Vector2 GetAimDirection()
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimDirection = (mousePosition - playerPosition).normalized;

            return aimDirection;
        }

        private Vector2 GetDotPosition(float time)
        {
            Vector2 position = (Vector2)player.transform.position
                + new Vector2(GetAimDirection().x, GetAimDirection().y) * time
                + 0.5f * (Physics2D.gravity * swordGravity) * (time * time);

            return position;
        }
    }
}
