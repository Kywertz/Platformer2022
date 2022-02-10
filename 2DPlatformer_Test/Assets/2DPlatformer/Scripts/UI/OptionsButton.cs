using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionslayout = null;

    [SerializeField]
    private GameObject _pauseMenuCanvas = null;

    [SerializeField]
    private GameObject _buttonFocus = null;

   
    public void ShowOptions()
    {
        _optionslayout.SetActive(true);
        _pauseMenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_buttonFocus.gameObject);
    }

    public void ResumeClicked()
    {
        _optionslayout.SetActive(false);
    }

}
