namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class HealSpell : MonoBehaviour
    {

        [SerializeField]
        private int _healthToChange = 1;

        private InputAction _inputaction = null;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private void OnEnable()
        {
            if (_inputActionmap.TryFindAction("HealSpell", out InputAction _inputaction) == true)
            {
                _inputaction.performed -= PlayerControllerHealSpellPerformed;
                _inputaction.performed += PlayerControllerHealSpellPerformed;
            }
            _inputaction.Enable();
        }

        private void OnDisable()
        {
            _inputaction.performed -= PlayerControllerHealSpellPerformed;
            _inputaction.Disable();
        }
        private void Jsp()
        {
            if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable playerDamageable) == true)
            {

                playerDamageable.RestoreHealth(_healthToChange);

            }
        }

        private void PlayerControllerHealSpellPerformed(/*PlayerController sender,*/ InputAction.CallbackContext obj)
        {

            Jsp();
            LevelReferences.Instance.SpellManager.UsingSpell(1);
        }
    }

}