namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class RatShield : MonoBehaviour
    {


        [SerializeField]
        private GameObject _ratshieldObject = null;

        private bool _startdown = false;

        private float _cooldown = 1f;

        [SerializeField]
        private float _bigfloat = 2f;

        //[SerializeField]
        //private InteractWithDamageable _projectileInteractWith = 0f;

        //[SerializeField]
        //private InteractWithDamageable _damageDealerInteractWith = 0f;

        private InputAction _inputaction = null;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private bool _starttimer = false;

        //[SerializeField]
        //private PlayerController _playerController = null;

        //[SerializeField]
        //private float _force = 1f;


        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("WallRatSpell", out InputAction _inputaction) == true)
            {
                _inputaction.performed -= PlayerControllerRatShieldPerformed;
                _inputaction.performed += PlayerControllerRatShieldPerformed;
            }
            _inputaction.Enable();
        }

        private void OnDisable()
        {
            _inputaction.performed -= PlayerControllerRatShieldPerformed;
            _inputaction.Disable();
        }


        private void Update()
        {
            if (_starttimer == true)
            {
                _bigfloat -= Time.deltaTime;

            }

            if (_bigfloat < 0)
            {
                _ratshieldObject.SetActive(false);
                _starttimer = false;
                _bigfloat = 0.2f;
                _startdown = true;
            }

            if (_startdown == true)
            {
                _cooldown -= Time.deltaTime;
            }

            if (_cooldown < 0)
            {
                _startdown = false;
                _cooldown = 1f;
            }
        }

        private void PlayerControllerRatShieldPerformed(/*PlayerController sender,*/ InputAction.CallbackContext obj)
        {

            if (_startdown == false)
            {
                _ratshieldObject.SetActive(true);
                _starttimer = true;
                LevelReferences.Instance.SpellManager.UsingSpell(1);
            }

        }


    }
}