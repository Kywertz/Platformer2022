namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    public class StoryManyPages : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _images = null;

        private bool _enterontrigger = false;

        [SerializeField]
        private GameObject _textpressytoshow = null;

        private bool _firsttimesee = false;

        private InputAction _inputaction = null;

        private int _currentIndex = -1;

        [SerializeField]
        private InputActionMapWrapper _inputtodo = null;


        private void OnEnable()
        {
            //if (_inputtodo.TryFindAction("AbilityImproverInteraction", out _inputaction) == true)
            //{
            //    _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
            //    _inputaction.performed += AbilityImproverInteractionInputAction_performed;
            //    _inputaction.Enable();
            //}
        }

        private void OnDisable()
        {
            _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
            _inputaction.Disable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {
                if (_inputtodo.TryFindAction("AbilityImproverInteraction", out _inputaction) == true)
                {
                    _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
                    _inputaction.performed += AbilityImproverInteractionInputAction_performed;
                    _inputaction.Enable();
                }
                _textpressytoshow.SetActive(true);
                _firsttimesee = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {

                _textpressytoshow.SetActive(false);
                _firsttimesee = false;
            }
        }

        private void ShowNextPage()
        {
            if (_firsttimesee == false)
            {
                return;
            }

            if (_currentIndex >= 0)
            {
                _images[_currentIndex].SetActive(false);
            }
            _currentIndex++;
            if (_currentIndex < _images.Length)
            {
                _images[_currentIndex].SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                _currentIndex = -1;
            }

        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
           
            if (_firsttimesee == true)
            {
                Debug.Log("ACTIONPRESSED");
                Time.timeScale = 0;
                ShowNextPage();
            }

        }


    }

}