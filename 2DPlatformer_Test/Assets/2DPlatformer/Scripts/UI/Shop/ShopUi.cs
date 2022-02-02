namespace GSGD2.Gameplay
{
    using GSGD2.Extensions;
    using GSGD2.Player;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Cinemachine;
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
        private GameObject _cameraSetup = null;

        [SerializeField]
        private GameObject _cameraRemove = null;

        private bool _isShopOpen = false;

        [SerializeField]
        private CinemachineVirtualCamera _cameraTest = null;

        [SerializeField]
        private CubeController _cubeController = null;

        [SerializeField]
        private GameObject _childrenPrefab = null;

        public bool _upgradetaken = true;

        [SerializeField]
        private GameObject _projectilelauncher = null;

        public void TryAddJumpForce(int removedloot)
        {
            //verifier si le loot n'est pas égale à zéro ou est au dessus de la valeure demander par le shop avant d'apply
            if (LevelReferences.Instance.LootManager.CurrentLoot >= removedloot)
            {
                LevelReferences.Instance.LootManager.RemoveLoot(removedloot);
                Pickup();

            }
            else
            {
                Debug.Log("YOU CANT DO THIS TRADE");
            }
        }

        private void Pickup()
        {

            _upgradetaken = true;
            _projectilelauncher.SetActive(true);
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
            if (ApplicationExtension.IsPlaying == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.Disable();
            }
        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            //verif si enter et si + 0 $ avec spot puis affiche l'ui du shop
            OpenShop();
        }

        private void OpenShop()
        {
            if (_isShopOpen == true)
            {
                _isShopOpen = false;
                _shop.SetActive(false);
                _text.SetActive(true);
                //_cameraSetup.SetActive(false);
                //_cameraRemove.gameObject.SetActive(true);
                print(_isShopOpen);
                _cameraTest.gameObject.SetActive(true);
                //_cameraTest.m_Lens.FieldOfView = 60;
            }

            else
            {
                _isShopOpen = true;
                _shop.SetActive(true);
                _text.SetActive(false);
                //_cameraRemove.gameObject.SetActive(false);
                //_cameraSetup.SetActive(true);
                print(_isShopOpen);
                //_cameraTest.gameObject.SetActive(true);
                //_cameraTest.m_Lens.FieldOfView = 10;
                //_cameraTest.LookAt.gameObject.transform.position = Vector3.zero;
            }
            
        }
        
        
        GameObject ICommandSender.GetGameObject() => gameObject;
    }
  



}