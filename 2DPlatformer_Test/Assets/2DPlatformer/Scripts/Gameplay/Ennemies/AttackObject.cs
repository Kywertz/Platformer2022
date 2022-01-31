using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    // Start is called before the first frame update
    private float _float = 0.2f;
    private bool _lebool = true;
    public void DestroyMePlease()
    {
        _lebool = true;
       
    }

    private void Update()
    {
        Debug.LogFormat("{0}, {1}", _float, _lebool);

        if (_lebool == true)
        {
            _float -= Time.deltaTime;

        }

        if (_float < 0)
        {
            Destroy(gameObject);
            _float = 0.2f;
        }

    }




}
