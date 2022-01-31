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
        private LayerMask _wallLayer;

        [SerializeField]
        private float _radius = 2f;

        [SerializeField]
        private float _wallMaxDistance = 20f;

        [SerializeField]
        private float _maxDistance = 20f;

        [SerializeField]
        private float _speed = 2f;

        [SerializeField]
        private float gravityscale = 1f;



        private bool foundPlayerTest = false;

        [SerializeField]
        private Transform test;


        private void Update()
        {

            //float angleee = Vector3.Angle(transform.forward, test.transform.position - transform.position);
            //bool isPlayerIsInFrontOfeee = angleee > 180;
            //Debug.LogFormat("{0}", angleee);

            // Sensor qu' est ce qui se passe ?
            bool isItAWall = false;
            bool wallRaycastResult = Physics.Raycast(fromTransform.position, fromTransform.forward, out RaycastHit wallHit, _wallMaxDistance, _wallLayer);
            Debug.DrawLine(fromTransform.position, fromTransform.position + fromTransform.forward * _wallMaxDistance);

            if (wallRaycastResult == true)
            {
                isItAWall = Vector3.Dot(wallHit.normal, -transform.forward) == 1;
            }

            bool hasFoundPlayerInFrontOf = false;
            bool hasFoundPlayerBehind = false;

            // Conditions qu'est ce qu' on doit faire ?
            RaycastHit hit;
            // On verifie si le joueur est devant si il est devant go vers lui
            if (Physics.SphereCast(fromTransform.position, _radius, fromTransform.forward, out hit, 0.1f, _layer))
            {
                if (ReferenceEquals(hit.transform, LevelReferences.Instance.Player.transform))
                {
                    float angle = Vector3.Angle(transform.forward, hit.transform.position - transform.position);
                    bool isPlayerIsInFrontOf = angle > 90;

                    if (isPlayerIsInFrontOf == true)
                    {
                        hasFoundPlayerInFrontOf = true;
                    }
                    else
                    {
                        hasFoundPlayerBehind = true;
                    }
                }
            }

            bool hasFoundPlayer = hasFoundPlayerBehind || hasFoundPlayerInFrontOf;
            foundPlayerTest = hasFoundPlayer;


            // Execution qu'est ce qu'on fait 
            if (hasFoundPlayer == true)
            {
                Debug.LogFormat("HasFoundPlayer infront:{0} | behind:{1}", hasFoundPlayerInFrontOf, hasFoundPlayerBehind);

                Vector3 direction = new Vector3(0, 0, (LevelReferences.Instance.Player.transform.position - transform.position).z);

                if (hasFoundPlayerBehind == true)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (hasFoundPlayerInFrontOf == true)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                // player true + wall true
                if (isItAWall == true)
                {

                }
                // player true + wall false
                else
                {
                    transform.position += (direction).normalized * _speed * Time.deltaTime;
                }
            }
            else
            {
                // player false + wall true
                if (isItAWall == true)
                {
                    transform.rotation *= Quaternion.Euler(0, 180, 0);
                }
                // player false + wall false
                else
                {
                    transform.position += transform.forward * Time.deltaTime * _speed;
                }
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
            transform.position += /*(Physics.gravity * gravityscale +*/ transform.forward * Time.deltaTime * _speed;
        }

        private void OnDrawGizmos()
        {
            Color color = Gizmos.color;
            if (foundPlayerTest == true)
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawWireSphere(fromTransform.position, _radius);

            Gizmos.color = color;
        }

    }


}