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

        public bool IsQKeyDown()
        {
            return Input.GetKeyDown(KeyCode.Q);
        }

        public bool IsSpaceKeyDown()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public bool IsShiftKeyDown()
        {
            return Input.GetKeyDown(KeyCode.LeftShift);
        }

        public bool IsLeftMouseButtonDown()
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }

        public float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }
}
