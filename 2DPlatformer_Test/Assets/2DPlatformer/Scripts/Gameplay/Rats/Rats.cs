using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rats : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject _children = null;

    public void OnTakeChildren()
    {
        transform.position = _children.transform.position;
    }
}
