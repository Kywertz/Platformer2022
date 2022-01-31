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
            Time.timeScale = 1;

            if (ApplicationExtension.IsPlaying == true)
            {
                _pauseability.performed -= Pauseability_performed;
                _pauseability.Disable();
            }
        }



        public void Continue()
        {
            Time.timeScale = 1;
            _hlayoutofpause.SetActive(false);

        }
        private void Pauseability_performed(InputAction.CallbackContext obj)
        {
            Debug.Log("Test pause input");
            //verif si enter et si + 0 $ avec spot puis affiche l'ui du shop
            bool isLayoutActive = _hlayoutofpause.activeSelf;

            if (isLayoutActive == true)
            {
                Time.timeScale = 1;
                _hlayoutofpause.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _hlayoutofpause.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_buttonFocus.gameObject);
            }

        }


    }
}