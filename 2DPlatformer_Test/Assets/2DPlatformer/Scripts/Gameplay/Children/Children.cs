namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;
    public class Children : MonoBehaviour
    {
        [SerializeField]
        private Transform _transformoffset = null;
        private bool _istaken = false;

        private void OnTriggerEnter(Collider other)
        {
            _istaken = true;
            
        }


        private void OnTriggerExit(Collider other)
        {
            //_istaken = false;
        }

        

        private void Update()
        {
            if (_istaken == true)
            {
                transform.position = _transformoffset.position;

            }
        }
    }

}