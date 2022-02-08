namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    public class Test_activated : MonoBehaviour
    {
        [SerializeField]
        private InputActionMapWrapper _inputActionMapWrapper = null;

        private InputAction _action = null;

        [SerializeField]
        GameObject _ratToLunch = null;

        private bool _isActivated = false;

        [SerializeField]
        GameObject _offsetOfThePlayer = null;

        private void OnEnable()
        {

            if (_inputActionMapWrapper.TryFindAction("SecondAttackDefaultInput", out _action, true))
            {
                _action.performed -= _action_performed;
                _action.performed += _action_performed;
                _isActivated = true;
            }
        }

        private void OnDisable()
        {
            _action.performed -= _action_performed;
            _action.Disable();
        }

        private void _action_performed(InputAction.CallbackContext obj)
        {
            if (LevelReferences.Instance.SpellManager.CurrentSpell > 0)
            {

                Instantiate(_ratToLunch, _offsetOfThePlayer.transform.position, transform.rotation);
                LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._ratlaunch);
                LevelReferences.Instance.SpellManager.UsingSpell(1);

            }
        }

        private void Update()
        {
            if (_isActivated == true)
            {
                if (_inputActionMapWrapper.TryFindAction("SecondAttackDefaultInput", out _action, true))
                {
                    _action.performed -= _action_performed;
                    _action.performed += _action_performed;
                }
            }
            else
            {
                _action.performed -= _action_performed;
                _action.Disable();
            }
        }

    }



}