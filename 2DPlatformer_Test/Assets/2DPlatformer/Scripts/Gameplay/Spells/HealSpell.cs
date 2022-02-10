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

        [SerializeField]
        private GameObject _healVFX = null;
        private InputAction _inputaction = null;
        private float _timeOfVfx = 1f;
        private bool _vfxstarted = false;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private void OnEnable()
        {
            if (Time.timeScale == 1)
            {
                if (_inputActionmap.TryFindAction("HealSpell", out InputAction _inputaction) == true)
                {
                    _inputaction.performed -= PlayerControllerHealSpellPerformed;
                    _inputaction.performed += PlayerControllerHealSpellPerformed;
                }
                _inputaction.Enable();
            }
            //if (_inputActionmap.TryFindAction("HealSpell", out InputAction _inputaction) == true)
            //{
            //    _inputaction.performed -= PlayerControllerHealSpellPerformed;
            //    _inputaction.performed += PlayerControllerHealSpellPerformed;
            //}
            //_inputaction.Enable();
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
                _healVFX.SetActive(true);
                _vfxstarted = true;
            }
        }

        private void PlayerControllerHealSpellPerformed(/*PlayerController sender,*/ InputAction.CallbackContext obj)
        {

            //Jsp();
            if (LevelReferences.Instance.SpellManager._currentspell > 0)
            {
                Jsp();
                LevelReferences.Instance.SpellManager.UsingSpell(1);
                LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._heal);
            }
            //LevelReferences.Instance.SpellManager.UsingSpell(1);
            //LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._heal);
        }

        private void Update()
        {
            if (_vfxstarted)
            {
                _timeOfVfx -= Time.deltaTime;
            }

            if (_timeOfVfx == 0 || _timeOfVfx < 0)
            {
                _healVFX.SetActive(false);
                _vfxstarted = false;
                _timeOfVfx = 1f;
            }
        }

    }

}