namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;
    public class Ennemies : MonoBehaviour
    {

 

        [SerializeField]
        private Transform fromTransform = null;

        [SerializeField]
        private LayerMask _layer;

        [SerializeField]
        private float _radius = 10f;


        [SerializeField]
        private float _maxDistance = 20f;

        [SerializeField]
        private float _speed = 2f;

        [SerializeField]
        private float gravityscale = 1f;

        private bool _canmove = true;

        private void Update()
        {
            //Raycast();
            if (_canmove == true)
            {
                EnnemieMove();

            }

            //if (_charactercollision.HasAWallInFrontOfCharacter && _charactercollision.HasAWallNearCharacter == true)
            //{
            //    Debug.Log("WallInFront");
            //    transform.rotation = Quaternion.Euler(0, 180, 0);
            //}

            //if (/*leraycast voit le player alors il get sa position et se dirige vers lui*/true)
            //{
            //    transform.position += (LevelReferences.Instance.Player.transform.position - transform.position).normalized * _speed * Time.deltaTime;
            //}


            RaycastHit hit;
            
           if(Physics.SphereCast(fromTransform.position, _radius, fromTransform.forward, out hit, _maxDistance, _layer))
           {
                _canmove = false;
                Debug.Log(hit.transform.name);
                if(ReferenceEquals( hit.transform , LevelReferences.Instance.Player.transform))
                {
                    Vector3 direction = LevelReferences.Instance.Player.transform.position - transform.position;
                    direction.x = 0;
                    direction.y = 0;
                    transform.position += (direction).normalized * _speed * Time.deltaTime;
                    //transform.rotation = ;
                }
                //else
                //{
                //    transform.rotation = Quaternion.Euler(0, 180, 0);
                //}
                
           }
            
        }


        //private void OnTriggerEnter(Collider other)
        //{
        //    if(other = LevelReferences.Instance.Player.Collider)
        //    {
        //        transform.position += (LevelReferences.Instance.Player.transform.position - transform.position).normalized * _speed * Time.deltaTime;
        //    }
        //}

        private void EnnemieMove()
        {
            transform.position += (Physics.gravity * gravityscale +transform.forward) * Time.deltaTime * _speed;
        }

    }

    
}