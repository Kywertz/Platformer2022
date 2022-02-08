using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipVfx : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _ParticleSystem = null;

    private void test()
    {
        ParticleSystemRenderer _tmpA = _ParticleSystem.GetComponent<ParticleSystemRenderer>();
        if (transform.rotation == Quaternion.Euler(0,0,0))
        {
            _tmpA.flip = new Vector3(0, 0, 0);
        }

    }
}

