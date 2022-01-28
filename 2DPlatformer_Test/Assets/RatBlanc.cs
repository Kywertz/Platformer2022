using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBlanc : MonoBehaviour
{
    [SerializeField]
    private GameObject _ratblancProjectile = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _ratblancProjectile)
        {
            Destroy(this);
        }
    }
}
