using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _ennemies = null;
    public void SpawnEnnemies()
    {
        Instantiate(_ennemies, transform.position, transform.rotation);
    }
}
