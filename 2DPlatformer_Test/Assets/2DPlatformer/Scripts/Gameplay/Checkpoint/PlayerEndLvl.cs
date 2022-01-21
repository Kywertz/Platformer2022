using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLvl : MonoBehaviour
{
    [SerializeField]
    private GameObject _hlayoutendlvl = null;

    private void OnTriggerEnter(Collider other)
    {
        _hlayoutendlvl.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _hlayoutendlvl.SetActive(false);
    }
}
