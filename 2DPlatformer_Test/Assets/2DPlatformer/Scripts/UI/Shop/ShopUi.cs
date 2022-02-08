namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    using GSGD2.Extensions;
    using TMPro;
    using UnityEngine.EventSystems;
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
        private GameObject _buttonFocus = null;

        private bool _isShopOpen = false;

        [SerializeField]
        private CubeController _cubeController = null;



        public bool _upgradetaken = false;

        [SerializeField]
        private GameObject _fluteswitcher = null;

        public void TryAddJumpForce(int removedloot)
        {
            //verifier si le loot n'est pas égale à zéro ou est au dessus de la valeure demander par le shop avant d'apply
            if (LevelReferences.Instance.LootManager.CurrentLoot >= removedloot)
            {
                LevelReferences.Instance.LootManager.RemoveLoot(removedloot);
                Pickup();
                _text.SetActive(true);
                _shop.SetActive(false);
                _cubeController.gameObject.SetActive(true);
                _isShopOpen = false;
                LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._clickOnButton);
            }
            else
            {

            }
        }

        private void Pickup()
        {

            _upgradetaken = true;
            //_fluteswitcher.set(true);
            //_projectilelaucheritem.CurrentState = Item.State.Held;
            //Destroy(_childrenPrefab);
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
            _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
            _abilityImproverInteractionInputAction.Disable();
        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {

            if (_isShopOpen == false)
            {
                _shop.SetActive(true);
                _text.SetActive(false);
                EventSystem.current.SetSelectedGameObject(_buttonFocus.gameObject);
                _isShopOpen = true;
                _cubeController.gameObject.SetActive(false);
            }
            else
            {
                _text.SetActive(true);
                _shop.SetActive(false);
                _isShopOpen = false;
                _cubeController.gameObject.SetActive(true);
            }
        }

        public void CloseShop()
        {
            _text.SetActive(true);
            _shop.SetActive(false);
            _isShopOpen = false;
            _cubeController.gameObject.SetActive(true);
            LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._clickOnButton);
        }
        GameObject ICommandSender.GetGameObject() => gameObject;


    }



}