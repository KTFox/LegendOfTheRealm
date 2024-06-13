using System;
using UnityEngine;

namespace LegendOfTheRealm.Managers
{
    public class InputManager : MonoBehaviour
    {
        // Variables

        public static InputManager Instance;

        private PlayerInputAction inputAction;

        // Events

        public event Action OnJump;


        // Methods

        private void Awake()
        {
            Instance = this;
            inputAction = new PlayerInputAction();

            inputAction.Player.Enable();
            inputAction.Player.Jump.performed += Jump_performed;
        }

        private void OnDestroy()
        {
            inputAction.Player.Disable();
            inputAction.Player.Jump.performed -= Jump_performed;
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        public Vector2 GetNormallizedMovementVector()
        {
            return inputAction.Player.Move.ReadValue<Vector2>().normalized;
        }
    }
}
