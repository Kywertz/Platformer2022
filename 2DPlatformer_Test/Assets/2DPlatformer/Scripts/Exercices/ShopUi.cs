namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    using GSGD2.Extensions;
    using TMPro;
    public class ShopUi : MonoBehaviour
    {
        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;
        private InputAction _abilityImproverInteractionInputAction = null;
        [SerializeField]
        private GameObject _shop = null;
        [SerializeField] 
        private GameObject _text = null;
        [SerializeField]
        private PickupCommand _pickupCommand = null;
        public void TryAddJumpForce(int force)
        {
            LevelReferences.Instance.LootManager.RemoveLoot(force);
            bool okay = true;
            if (okay == true)
            {
                Pickup(); 
            }
            //LevelReferences.Instance.Player.AddMaximumAllowedForceToJump(force);

        }

        public  void Pickup()
        {
            //_pickupCommand.Apply(this);
        }
      

        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("AbilityImproverInteraction", out _abilityImproverInteractionInputAction) == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.performed += AbilityImproverInteractionInputAction_performed;
                
            }

            _abilityImproverInteractionInputAction.Enable();
            
            //GetComponentsInChildren.SetActive(false);
        }



        private void OnDisable()
        {
            if (ApplicationExtension.IsPlaying == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.Disable();
                _shop.SetActive(false);
                _text.SetActive(true);
            }
        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            Debug.Log("Test input");
            //verif si enter et si + 0 $ avec spot puis affiche l'ui du shop
            _shop.SetActive(true);
            _text.SetActive(false);
        }
    }



}