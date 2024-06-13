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
        public event Action OnDash;
        public event Action OnAttack;
        public event Action OnCounterAttack;


        // Methods

        private void Awake()
        {
            Instance = this;
            inputAction = new PlayerInputAction();

            inputAction.Player.Enable();
            inputAction.Player.Jump.performed += Jump_performed;
            inputAction.Player.Dash.performed += Dash_performed;
            inputAction.Player.Attack.performed += Attack_performed;
            inputAction.Player.AttackCounter.performed += AttackCounter_performed;
        }

        private void OnDestroy()
        {
            inputAction.Player.Disable();
            inputAction.Player.Jump.performed -= Jump_performed;
            inputAction.Player.Dash.performed -= Dash_performed;
            inputAction.Player.Attack.performed -= Attack_performed;
            inputAction.Player.AttackCounter.performed -= AttackCounter_performed;
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnDash?.Invoke();
        }

        private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnAttack?.Invoke();
        }

        private void AttackCounter_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnCounterAttack?.Invoke();
        }

        public Vector2 GetNormallizedMovementVector()
        {
            return inputAction.Player.Move.ReadValue<Vector2>().normalized;
        }
    }
}
