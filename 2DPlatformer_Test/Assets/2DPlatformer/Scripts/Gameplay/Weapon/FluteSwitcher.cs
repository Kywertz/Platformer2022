namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    public class FluteSwitcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject _secondAttack = null;

        [SerializeField]
        private GameObject _upgradeOfSecondAttack = null;

        private InputAction _inputAction;

        [SerializeField]
        private InputActionMapWrapper _inputActionMapwrapper = null;

        [SerializeField]
        private ShopUi _ShopUi = null;

        private void OnEnable()
        {
            if (_inputActionMapwrapper.TryFindAction("SwitchUpgradeAttack", out _inputAction, true))
            {
                _inputAction.performed -= _inputAction_performed;
                _inputAction.performed += _inputAction_performed;
            }
            _inputAction.Enable();
        }

        private void _inputAction_performed(InputAction.CallbackContext obj)
        {
            if (_ShopUi._upgradetaken == true)
            {
                bool activeself = _secondAttack.activeSelf;
                _secondAttack.SetActive(activeself == false);
                _upgradeOfSecondAttack.SetActive(activeself);
            }
        }

        private void OnDisable()
        {
            _inputAction.performed -= _inputAction_performed;
            _inputAction.Disable();
        }



    } 
}