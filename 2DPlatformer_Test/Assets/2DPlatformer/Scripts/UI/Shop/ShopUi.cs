namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    using GSGD2.Extensions;
    using TMPro;
    public class ShopUi : MonoBehaviour, ICommandSender
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
        [SerializeField]
        private LootHUD _loothud = null;

        [SerializeField]
        private GameObject _childrenPrefab = null;

        public bool _upgradetaken = false;

        public void TryAddJumpForce(int removedloot)
        {
            //verifier si le loot n'est pas égale à zéro ou est au dessus de la valeure demander par le shop avant d'apply
            if(LevelReferences.Instance.LootManager.CurrentLoot >= removedloot)
            {
                LevelReferences.Instance.LootManager.RemoveLoot(removedloot);
                Pickup();

            }
            else
            {
                Debug.Log("YOU CANT DO THIS TRADE");
            }
        }

        private  void Pickup()
        {
         
            _upgradetaken = true;
            Destroy(_childrenPrefab);
        }
      

        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("AbilityImproverInteraction", out _abilityImproverInteractionInputAction) == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.performed += AbilityImproverInteractionInputAction_performed;
                
            }

            _abilityImproverInteractionInputAction.Enable();
            
           
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
            
            //verif si enter et si + 0 $ avec spot puis affiche l'ui du shop
            _shop.SetActive(true);
            _text.SetActive(false);
        }
        GameObject ICommandSender.GetGameObject() => gameObject;

    }



}