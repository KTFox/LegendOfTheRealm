using LegendOfTheRealm.Managers;
using UnityEngine;

namespace LegendOfTheRealm.UI
{
    public class ToggleUI : MonoBehaviour
    {
        // Variables

        [SerializeField] private GameObject bookUI;


        // Methods

        private void Start()
        {
            InputManager.Instance.OnToggleBookUI += InputManager_OnToggleBookUI;

            bookUI.SetActive(false);
        }

        private void InputManager_OnToggleBookUI()
        {
            bookUI.SetActive(!bookUI.activeSelf);
        }
    }
}
