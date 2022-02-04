namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    public class SwitchSecondAttack : MonoBehaviour
    {

        [SerializeField]
        private ShopUi _shopui = null;

        [SerializeField]
        private UpgradeSecondAttack _upgradeSecondAttack = null;

        [SerializeField]
        private InputActionMapWrapper _mapwrapper = null;

        private InputAction _testInputAction = null;

        private void Update()
        {
            if (_shopui._upgradetaken == true)
            {
                if (_mapwrapper.TryFindAction("SwitchUpgradeAttack", out _testInputAction) == true)
                {

                    _testInputAction.performed -= OtherInputAction_performed;
                    _testInputAction.performed += OtherInputAction_performed;
                    _testInputAction.Enable();
                }
            }

        }
        private void OtherInputAction_performed(InputAction.CallbackContext obj)
        {

            if (_upgradeSecondAttack._desactivated == false)
            {

                _upgradeSecondAttack._desactivated = true;

            }
            else
            {

                _upgradeSecondAttack._desactivated = false;

            }
        }

    }
}
