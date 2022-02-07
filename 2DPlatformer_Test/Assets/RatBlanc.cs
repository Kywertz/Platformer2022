using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBlanc : MonoBehaviour
{
    [SerializeField]
    private GameObject _ratblancProjectile = null;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("{0}", other.tag);

        if (other.tag == "RatBlanc")
        {
            Destroy(gameObject);
        }
    }
}
