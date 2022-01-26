namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Gameplay;

    public class MovableController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody = null;

        private GameObject _objecttomove = null;

        [SerializeField]
        private CubeController _cubecontroller = null;

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


        // en push pousser l'objet en direction forward du joueur quand le joueur avance et appuie sur la touche, en pull tirer l'objet vers le joueur ( l'attacher ?) touche + avance aussi
        // si le player appuie sur la touche et va vers son avant alors ça pousse sinon il tire
        //if ( _player move to his transform.forward)
        //{
        //_objecttomove.transform.position = objecttomove.transform.position + _player.transform.forward;
        //else
        //{
        //_objecttomove.transform.position = _=objectomove.transform.position - _player.transform.forward;
        //}
        //}

        private void Update()
        {

            if (_currentmovable == true && _canstartmove == true)
            {
                //_currentmovable = HorizontalMove;
                //_currentmovable = _playercontroller.HorizontalMove;
                _currentmovable.transform.position += _playercontroller.HorizontalMove * Time.deltaTime * transform.forward;
                Debug.Log("Deplacement");
            }


            //On Push
            //if (_playercontroller.transform.forward == _currentmovable.transform.forward)
            //{
            //  _currentmovable.transform.position += _playercontroller.transform.forward;

            //}
            ////On Pull
            //else
            //{
            //  _currentmovable.transform.position -= _playercontroller.transform.forward;

            //}
        }

        private void PlayerControllerPushPullPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            //je sait pas quoi mettre ici mais faut activer d'une certaine maniere ici klk chose
            //_currentmovable._canmove = true;
            _canstartmove = true;
        }

        public void Add(Movable movable)
        {
            _currentmovable = movable;
            Debug.Log("Added");
        }

        public void Remove(Movable movable)
        {
            _currentmovable = null;
            Debug.Log("Removed");
        }
    }

}