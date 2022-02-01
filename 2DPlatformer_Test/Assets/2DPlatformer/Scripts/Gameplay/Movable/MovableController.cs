namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Gameplay;

    public class MovableController : MonoBehaviour
    {
        

        private InputAction _grabability = null;

        private bool _canstartmove = false;
       
        private Movable _currentmovable = null;

        [SerializeField]
        InputActionMapWrapper _inputActionmap = null;

        [SerializeField]
        PlayerController _playercontroller = null;

        [SerializeField]
        private float _pushpullforce = 1f;

        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("PushPull", out _grabability) == true)
            {

                _playercontroller.PushPullPerformed -= PlayerControllerPushPullPerformed;
                _playercontroller.PushPullPerformed += PlayerControllerPushPullPerformed;
            }

        }

        private void OnDisable()
        {
            _playercontroller.PushPullPerformed -= PlayerControllerPushPullPerformed;
        }


     

        private void Update()
        {

            if (_currentmovable != null && _canstartmove == true)
            {
               
                _currentmovable.transform.position += _playercontroller.HorizontalMove * Time.deltaTime * transform.forward * _pushpullforce;
                Debug.Log("Deplacement");
            }


       
        }

        private void PlayerControllerPushPullPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            
            _canstartmove = obj.action.IsPressed();
            
            
        }

        public void Add(Movable movable)
        {
            _currentmovable = movable;
       
        }

        public void Remove(Movable movable)
        {
            _currentmovable = null;
            
        }
    }

}