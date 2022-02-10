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
            if (Time.timeScale == 1)
            {
                if (_inputMapWrapperAttack.TryFindAction("SecondAttackDefaultInput", out _inputaction, true))
                {
                    _inputaction.performed -= SecondAttack_Performed;
                    _inputaction.performed += SecondAttack_Performed;
                }
            }
            //if (_inputMapWrapperAttack.TryFindAction("SecondAttackDefaultInput", out _inputaction, true))
            //{
            //    _inputaction.performed -= SecondAttack_Performed;
            //    _inputaction.performed += SecondAttack_Performed;
            //}
           
        }

        private void OnDisable()
        {
            _inputaction.performed -= SecondAttack_Performed;
            _inputaction.Disable();
            
        }

        private void SecondAttack_Performed(InputAction.CallbackContext obj)
        {
            LevelReferences.Instance.SpellManager.UsingSpell(1);
            Shoot();

        }


        public void Shoot()
        {

            Instantiate(_rattolunch, _offset.transform.position, transform.rotation);
            LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._ratlaunch);
           
        }

       
    }

}