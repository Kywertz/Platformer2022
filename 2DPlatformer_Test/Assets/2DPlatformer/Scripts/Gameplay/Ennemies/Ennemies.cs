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
        private LayerMask _walllayer;

        private bool _seeplayer = false;

        [SerializeField]
        private float _radius = 2f;



        [SerializeField]
        private float _maxDistance = 20f;

        [SerializeField]
        private float _speed = 2f;

        [SerializeField]
        private float gravityscale = 1f;

        private bool _canmove = true;

        private void Update()
        {

            if (_canmove == true)
            {
                EnnemieMove();

            }

            RaycastHit hit;

            // On verifie si le joueur est devant si il est devant go vers lui
            if (Physics.SphereCast(fromTransform.position, _radius, fromTransform.forward, out hit, _maxDistance, _layer))
            {

                Debug.Log(hit.transform.name);

                if (ReferenceEquals(hit.transform, LevelReferences.Instance.Player.transform))
                {
                    _canmove = false;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Vector3 direction = LevelReferences.Instance.Player.transform.position - transform.position;
                    direction.x = 0;
                    direction.y = 0;
                    transform.position += (direction).normalized * _speed * Time.deltaTime;

                }
                else
                {
                    _canmove = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }






            }
            // On verifie si le joueur est derr si il est derr se retourne et go vers lui
            if (Physics.SphereCast(fromTransform.position, _radius, fromTransform.forward * -1, out hit, _maxDistance, _layer))
            {



                Debug.Log(hit.transform.name);

                if (ReferenceEquals(hit.transform, LevelReferences.Instance.Player.transform))
                {
                    _canmove = false;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    Vector3 direction = LevelReferences.Instance.Player.transform.position - transform.position;
                    direction.x = 0;
                    direction.y = 0;
                    transform.position += (direction).normalized * _speed * Time.deltaTime;
                    _seeplayer = true;

                }
                else
                {
                    _seeplayer = false;
                    _canmove = true;
                    if (_seeplayer == false)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    if (_seeplayer == true)
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }



            }

            //if (Physics.SphereCast(fromTransform.position, _radius, fromTransform.forward, out hit, _maxDistance, _walllayer))
            //{
            //    transform.rotation = Quaternion.Euler(0, 180, 0);
            //    transform.position += transform.forward * Time.deltaTime * _speed;
            //}
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
            transform.position += /*(Physics.gravity * gravityscale +*/ transform.forward * Time.deltaTime * _speed;
        }

    }


}