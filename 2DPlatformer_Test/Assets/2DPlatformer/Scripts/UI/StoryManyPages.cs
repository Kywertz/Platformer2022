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

        [SerializeField]
        private InputActionMapWrapper _inputtodo = null;


        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {

                _enterontrigger = true;
                _textpressytoshow.SetActive(true);
                _firsttimesee = true;
            }
        }

        private void test()
        {

        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            if (_enterontrigger == true)
            {
                
                for (int i = 0; i < _images.Length; i++)
                {
                    _images[0].SetActive(false);
                    _images[i++].SetActive(true);
                }
            }
        }


        private void Update()
        {
            if (_firsttimesee)
            {
                if (_inputtodo.TryFindAction("AbilityImproverInteraction", out _inputaction) == true)
                {
                    _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
                    _inputaction.performed += AbilityImproverInteractionInputAction_performed;
                    _inputaction.Enable();
                }

            }
        }
    }

}