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


        // Methods

        private void Awake()
        {
            Instance = this;
            inputAction = new PlayerInputAction();
            inputAction.Player.Enable();
        }

        public Vector2 GetNormallizedMovementVector()
        {
            return inputAction.Player.Move.ReadValue<Vector2>().normalized;
        }
    }
}
