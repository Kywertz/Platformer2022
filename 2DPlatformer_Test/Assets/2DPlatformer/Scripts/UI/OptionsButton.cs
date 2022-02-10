using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionslayout = null;

    [SerializeField]
    private GameObject _pauseMenuCanvas = null;

    public void ShowOptions()
    {
        _optionslayout.SetActive(true);
        _pauseMenuCanvas.SetActive(false);
    }

    public void ResumeClicked()
    {
        _optionslayout.SetActive(false);
    }

}
