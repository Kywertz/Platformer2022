namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class SecondAttack : MonoBehaviour
    {

        //[SerializeField]
        //private UpgradeSecondAttack _upgradeSecondAttack = null;

        [SerializeField]
        Projectile _rattolunch = null;

        [SerializeField]
        GameObject _offset = null;

        [SerializeField]
        private InputActionMapWrapper _inputMapWrapperAttack = null;

        private InputAction _inputaction = null;

        private void OnEnable()
        {
            if (_inputMapWrapperAttack.TryFindAction("SecondAttackDefaultInput", out _inputaction, true))
            {
                _inputaction.performed -= SecondAttack_Performed;
                _inputaction.performed += SecondAttack_Performed;
            }
            //_inputaction.Enable();
            Debug.Log("OnEnable");
        }

        private void OnDisable()
        {
            _inputaction.performed -= SecondAttack_Performed;
            _inputaction.Disable();
            Debug.Log("OnDisable");
        }

        private void SecondAttack_Performed(InputAction.CallbackContext obj)
        {
            //if (_upgradeSecondAttack._desactivated == true)
            //{


            //}
            Debug.Log("Performed");

            Shoot();
        }


        public void Shoot()
        {
            Instantiate(_rattolunch, _offset.transform.position, transform.rotation);
            LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._ratlaunch);
        }

       
    }

}