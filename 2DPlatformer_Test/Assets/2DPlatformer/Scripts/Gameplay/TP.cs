namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class TP : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tpEnd = null;

        [SerializeField]
        private InputActionMapWrapper _inputActionMap = null;

        [SerializeField]
        private CubeController _cubeController = null;

        [SerializeField]
        private GameObject _text = null;

        private InputAction InputActionY = null;

        private bool _onTrigger = false;


        private void OnEnable()
        {
            if (_inputActionMap.TryFindAction("InputActionY", out InputAction InputActionY) == true)

            {
                InputActionY.performed -= Action;
                InputActionY.performed += Action;
                InputActionY.Enable();

            }
        }
        private void OnDisable()
        {
            InputActionY.performed -= Action;

            InputActionY.Disable();
        }

        private void Action(InputAction.CallbackContext obj)
        {
            Teleport();
        }

        private void Teleport()
        {
            if (_onTrigger == true)
            {
                _cubeController.transform.position = _tpEnd.transform.position;
                print("ActiveInputAction");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _onTrigger = true;
            print(_onTrigger);
            _text.gameObject.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            _text.gameObject.SetActive(false);
            _onTrigger = false;
        }
    }

}