namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    public class Story : MonoBehaviour
    {

        [SerializeField]
        private GameObject _storytoshow = null;

        private InputAction _inputaction;

        private bool _firsttimesee = false;

        private bool _enterontrigger = false;

        [SerializeField]
        private InputActionMapWrapper _inputToDo = null;

        [SerializeField]
        private GameObject _textpressytoshow = null;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {

                _enterontrigger = true;
                _textpressytoshow.SetActive(true);
                _firsttimesee = true;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {

                _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
                _textpressytoshow.SetActive(false);
                _inputaction.Disable();
                _enterontrigger = false;
            }
        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            if (_enterontrigger == true)
            {
                _textpressytoshow.SetActive(false);
                _storytoshow.SetActive(true);
                
            }
            else
            {
                _storytoshow.SetActive(false);
            }
        }


        private void OnEnable()
        {
        }


        private void OnDisable()
        {
            _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
            _inputaction.Disable();
            _firsttimesee = false;

        }

        private void Update()
        {
            if (_firsttimesee)
            {
                if (_inputToDo.TryFindAction("AbilityImproverInteraction", out _inputaction) == true)
                {
                    _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
                    _inputaction.performed += AbilityImproverInteractionInputAction_performed;
                    _inputaction.Enable();
                } 

            }
        }
        
        
    }

}