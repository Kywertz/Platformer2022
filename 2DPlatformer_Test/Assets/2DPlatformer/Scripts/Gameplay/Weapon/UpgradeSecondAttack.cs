namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class UpgradeSecondAttack : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        float _rotation = 5f;

        [SerializeField]
        private ShopUi _shopui = null;

        public bool _desactivated = false;

        [SerializeField]
        float _currentRotation = 0;

        [SerializeField]
        private GameObject _offset = null;

        [SerializeField]
        private InputActionMapWrapper _mapwrapper = null;

        [SerializeField]
        private Projectile _projectile = null;

        [SerializeField] private string _testInput = "Ver";

        private InputAction _testInputAction;

        private InputAction _secondInputAction;

        private float VerAxis => _testInputAction.ReadValue<float>();


        private void OnEnable()
        {

            _mapwrapper.TryFindAction(_testInput, out _testInputAction, true);
            //if (_mapwrapper.TryFindAction("SeconAttackInput", out _testInputAction) == true)
            //{
            //    _testInputAction.performed -= AbilityImproverInteractionInputAction_performed;
            //    _testInputAction.performed += AbilityImproverInteractionInputAction_performed;
            //    _testInputAction.Enable();
            //}
            //if (_mapwrapper.TryFindAction("SwitchUpgradeAttack", out _secondInputAction) == true)
            //{
            //    _testInputAction.performed -= AbilityImproverInteractionInputAction_performed;
            //    _testInputAction.Disable();
            //    _testInputAction.performed += OtherInputAction_performed;
            //    _secondInputAction.Enable();
            //}

        }

        private void Update()
        {
            if (/*_shopui._upgradetaken == true*/ /*&&*/ _desactivated == false)
            {
                _currentRotation += (transform.rotation.x + _rotation) * VerAxis;
                transform.rotation = Quaternion.Euler(_currentRotation, 0, 0);

                //if (_mapwrapper.TryFindAction("SeconAttackInput", out _testInputAction) == true)
                //{
                //    _testInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                //    _testInputAction.performed += AbilityImproverInteractionInputAction_performed;
                //    _testInputAction.Enable();
                //}
                //if (_mapwrapper.TryFindAction("SwitchUpgradeAttack", out _secondInputAction) == true)
                //{
                //    _testInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                //    _testInputAction.Disable();
                //    _testInputAction.performed += OtherInputAction_performed;
                //    _secondInputAction.Enable();
                //}
            }
        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {

            LaunchProjectile();

        }


        private void OtherInputAction_performed(InputAction.CallbackContext obj)
        {

            _desactivated = true;
            gameObject.SetActive(false);

        }

        private void LaunchProjectile()
        {

            Projectile instance = Instantiate(_projectile, _offset.transform.position, _offset.transform.rotation);

        }

    }

}