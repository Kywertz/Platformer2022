namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private Ennemies _ennemies = null;



        public void SpawnEnnemies()
        {
            if(_ennemies._isdead == true)
            {
                
               Instantiate(_ennemies, transform.position, transform.rotation);

            }
        }
    }

}