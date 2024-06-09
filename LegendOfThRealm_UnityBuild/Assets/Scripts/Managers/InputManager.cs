using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class InputManager : MonoBehaviour
    {
        // Variables

        public static InputManager Instance;


        // Methods

        private void Awake()
        {
            Instance = this;
        }

        public bool IsKKeyDown()
        {
            return Input.GetKeyDown(KeyCode.K);
        }

        public bool IsLKeyDown()
        {
            return Input.GetKeyDown(KeyCode.L);
        }

        public bool IsJKeyDown()
        {
            return Input.GetKeyDown(KeyCode.J);
        }

        public float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }
}
