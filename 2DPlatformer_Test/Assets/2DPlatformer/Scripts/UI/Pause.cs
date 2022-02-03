namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using GSGD2.Extensions;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    using UnityEngine.EventSystems;

    public class Pause : MonoBehaviour
    {
        [SerializeField]
        private bool _loadAtOnEnable = false;

        private InputAction _pauseability = null;

        [SerializeField]
        private InputActionMapWrapper _inputActionmap = null;

        private InputAction _pauseAction = null;

        [SerializeField]
        private LoadSceneMode _mode = LoadSceneMode.Single;

        [SerializeField]
        private GameObject _hlayoutofpause = null;

        [SerializeField]
        private GameObject _buttonFocus = null;

        private bool _isPaused = false;

        private void OnEnable()
        {

            if (_inputActionmap.TryFindAction("Pause", out _pauseability) == true)
            {
                _pauseability.performed -= Pauseability_performed;
                _pauseability.performed += Pauseability_performed;

            }

            _pauseability.Enable();

        }

        private void OnDisable()
        {
            _pauseability.performed -= Pauseability_performed;
            _pauseability.Disable();
        }

        public void Continue()
        {
            Time.timeScale = 1;
            _hlayoutofpause.SetActive(false);
            _isPaused = false;
        }
        private void Pauseability_performed(InputAction.CallbackContext obj)
        {
            SetPause();
            print(_isPaused);
        }
        private void SetPause()
        {
            if (_isPaused == false)
            {
                EventSystem.current.SetSelectedGameObject(_buttonFocus.gameObject);
                Time.timeScale = 0;
                _hlayoutofpause.gameObject.SetActive(true);
                _isPaused = true;
            }
            else
            {
                _isPaused = false;
                Time.timeScale = 1;
                _hlayoutofpause.gameObject.SetActive(false);
            }
        }
    }
}