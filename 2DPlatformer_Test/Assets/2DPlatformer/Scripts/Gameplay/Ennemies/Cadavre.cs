namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    using GSGD2.Player;


    public class Cadavre : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private GameObject _canvas = null;

        private InputAction _inputaction;

        private bool _enteroncollider = false;

        [SerializeField]
        private InputActionMapWrapper _actiontoinput = null;


        private void OnEnable()
        {


        }


        private void OnDisable()
        {


            _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
            _inputaction.Disable();

            _canvas.SetActive(false);
        }


        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            if (_enteroncollider == true)
            {

                LevelReferences.Instance.SpellManager.AddSpell(1);
                LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._interactwithCorpse);
                Destroy(this.gameObject);
            }

        }


        private void OnTriggerEnter(Collider other)
        {

            if (other == LevelReferences.Instance.Player.Collider)
            {
                _enteroncollider = true;
                _canvas.SetActive(true);
                if (_actiontoinput.TryFindAction("AbilityImproverInteraction", out _inputaction) == true)
                {
                    _inputaction.performed -= AbilityImproverInteractionInputAction_performed;
                    _inputaction.performed += AbilityImproverInteractionInputAction_performed;
                    _inputaction.Enable();
                }



            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other = LevelReferences.Instance.Player.Collider)
            {
                //LevelReferences.Instance.SpellManager.AddSpell(1);
                // Destroy(gameObject);
                _canvas.SetActive(false);
                _enteroncollider = false;

            }
        }

    }

}