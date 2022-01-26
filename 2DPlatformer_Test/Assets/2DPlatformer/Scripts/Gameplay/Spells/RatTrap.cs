namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class RatTrap : MonoBehaviour, IDamageInstigator
    {

        [SerializeField]
        private GameObject _trapPrefab;

        [SerializeField]
        private GameObject _offset;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private InputAction _inputaction = null;

        [SerializeField]
        private InteractWithDamageable _ratrapinteractwith = 0f;
        [SerializeField]
        private InteractWithDamageable _damageDealerInteractWith = 0f;

        private bool CanUse = true;

        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("RatTrapSpell", out InputAction _inputaction) == true)
            {
                _inputaction.performed -= PlayerControllerRatTrapSpellPerformed;
                _inputaction.performed += PlayerControllerRatTrapSpellPerformed;
            }
            _inputaction.Enable();
        }

        private void OnDisable()
        {
            _inputaction.performed -= PlayerControllerRatTrapSpellPerformed;
            _inputaction.Disable();
        }

        private void SpawnTrap()
        {
            if (CanUse == true)
            {
                GameObject instance = Instantiate(_trapPrefab, _offset.transform.position, _offset.transform.rotation);


                //instance.SetInteractWith(_ratrapinteractwith);
                if (instance.TryGetComponent(out DamageDealer damageDealer) == true)
                {
                    damageDealer.SetInstigator(this);
                    damageDealer.SetInteractWith(_damageDealerInteractWith);
                }
            }
            Debug.Log("C'est good bg");
            LevelReferences.Instance.SpellManager.UsingSpell(1);
        }
        private void PlayerControllerRatTrapSpellPerformed(/*PlayerController sender,*/ InputAction.CallbackContext obj)
        {
            Debug.Log("TestInput Trap");
            SpawnTrap();

        }
        Transform IDamageInstigator.GetTransform() => transform;
    }

}