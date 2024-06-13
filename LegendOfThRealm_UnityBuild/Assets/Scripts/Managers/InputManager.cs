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

        public bool IsRightMouseButtonDown()
        {
            return Input.GetKeyDown(KeyCode.Mouse1);
        }

        public bool IsRightMouseButtonUp()
        {
            return Input.GetKeyUp(KeyCode.Mouse1);
        }

        public bool IsHoldRightMouseButton()
        {
            return Input.GetKey(KeyCode.Mouse1);
        }

        public float GetHorizontalInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }
}
