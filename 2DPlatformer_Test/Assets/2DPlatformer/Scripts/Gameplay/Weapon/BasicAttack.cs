namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class BasicAttack : MonoBehaviour
    {

        [SerializeField]
        private GameObject _fluteattackPrefab = null;

        private bool _startdown = false;

        [SerializeField]
        private GameObject _offset = null;


        private float _cooldown = 1f;

        [SerializeField]
        private float _bigfloat = 2f;

       

        private InputAction _inputaction = null;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private bool _starttimer = false;

        [SerializeField]
        private AttackObject _attackobject = null;

       


        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("BasicAttack", out InputAction _inputaction) == true)
            {
                _inputaction.performed -= PlayerControllerBasicAttackPerformed;
                _inputaction.performed += PlayerControllerBasicAttackPerformed;
            }
            _inputaction.Enable();
        }

        private void OnDisable()
        {
            _inputaction.performed -= PlayerControllerBasicAttackPerformed;
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
               
                _attackobject.DestroyMePlease();
                _starttimer = false;
                _bigfloat = 0.2f;
                _startdown = true;
            }

            if(_startdown == true)
            {
                _cooldown -= Time.deltaTime;
            }

            if (_cooldown < 0)
            {
                _startdown = false;
                _cooldown = 1f;
            }
        }

        private void PlayerControllerBasicAttackPerformed( InputAction.CallbackContext obj)
        {
            
           
            if (_startdown == false)
            {
                
                Instantiate(_fluteattackPrefab, _offset.transform.position, _offset.transform.rotation);
                _starttimer = true;
            }
          
        }

    
    }
}