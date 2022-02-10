using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBlanc : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("{0}", other.tag);

        if (other.tag == "RatBlanc")
        {
            Destroy(gameObject);
        }
    }
}
