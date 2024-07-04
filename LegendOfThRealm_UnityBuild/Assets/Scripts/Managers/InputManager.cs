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
        public event Action OnToggleBookUI;
        public event Action OnUseItem1;
        public event Action OnUseItem2;
        public event Action OnUseItem3;
        public event Action OnHeavyAttack;


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
            inputAction.Player.ToggleBookUI.performed += ToggleBookUI_performed;
            inputAction.Player.UseItem1.performed += UseItem1_performed;
            inputAction.Player.UseItem2.performed += UseItem2_performed;
            inputAction.Player.UseItem3.performed += UseItem3_performed;
            inputAction.Player.HeavyAttack.performed += HeavyAttack_performed;
        }

        private void OnDestroy()
        {
            inputAction.Player.Disable();
            inputAction.Player.Jump.performed -= Jump_performed;
            inputAction.Player.Dash.performed -= Dash_performed;
            inputAction.Player.Attack.performed -= Attack_performed;
            inputAction.Player.AttackCounter.performed -= AttackCounter_performed;
            inputAction.Player.HeavyAttack.performed -= HeavyAttack_performed;
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

        private void ToggleBookUI_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnToggleBookUI?.Invoke();
        }

        private void UseItem1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnUseItem1?.Invoke();
        }

        private void UseItem2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnUseItem2?.Invoke();
        }

        private void UseItem3_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnUseItem3?.Invoke();
        }

        private void HeavyAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnHeavyAttack?.Invoke();
        }

        public Vector2 GetNormallizedMovementVector()
        {
            return inputAction.Player.Move.ReadValue<Vector2>().normalized;
        }
    }
}
