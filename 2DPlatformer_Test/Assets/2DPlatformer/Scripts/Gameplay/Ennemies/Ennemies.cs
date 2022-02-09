namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;
    public class Ennemies : MonoBehaviour
    {

        public bool _isdead = false;

        [SerializeField]
        private Transform fromTransform = null;

        [SerializeField]
        private LayerMask _layer;

        [SerializeField]
        private DamageDealer _damageDealer = null;

        [SerializeField]
        private LayerMask _wallLayer;

        [SerializeField]
        private float _radius = 2f;

        [SerializeField]
        private float _wallMaxDistance = 5f;


        [SerializeField]
        private float _speed = 2f;


        private bool foundPlayerTest = false;

        [SerializeField]
        private GameObject _offset = null;

        [SerializeField]
        private GameObject _cadavretospawn = null;

        [SerializeField]
        PnjAnimator _pnjanimator = null;

        private void Update()
        {
           

            
            
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
                if (Physics.SphereCast(fromTransform.position, _radius, fromTransform.position, out hit, 0.1f, _layer))
                {
                    //Debug.LogFormat("{0}", hit);
                    if (ReferenceEquals(hit.transform, LevelReferences.Instance.Player.transform))
                    {

                        float angle = Vector3.Angle(transform.forward, hit.transform.position - transform.position);
                        bool isPlayerIsInFrontOf = angle < 90;
                        Debug.LogFormat("{0}", angle);

                        if (isPlayerIsInFrontOf == true)
                        {

                            hasFoundPlayerInFrontOf = true;
                            hasFoundPlayerBehind = false;
                        }
                        else
                        {

                            hasFoundPlayerBehind = true;
                            hasFoundPlayerInFrontOf = false;
                        }
                    }
                }

                bool hasFoundPlayer = hasFoundPlayerBehind || hasFoundPlayerInFrontOf;
                foundPlayerTest = hasFoundPlayer;

            if (_pnjanimator._stopmoving == false) 
            {

                // Execution qu'est ce qu'on fait 
                if (hasFoundPlayer == true)
                {
                    Debug.LogFormat("HasFoundPlayer infront:{0} | behind:{1}", hasFoundPlayerInFrontOf, hasFoundPlayerBehind);

                    Vector3 direction = new Vector3(0, 0, (LevelReferences.Instance.Player.transform.position - transform.position).z);

                    if (hasFoundPlayerBehind == true)
                    {
                        _damageDealer._ignorePlayer = false;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._playerSpotted);

                        //hasFoundPlayerInFrontOf = false;
                    }
                    else if (hasFoundPlayerInFrontOf == true)
                    {

                        _damageDealer._ignorePlayer = false;



                    }


                    if (isItAWall == true)
                    {
                        _damageDealer._ignorePlayer = true;
                    }

                    else
                    {

                        transform.position += (direction).normalized * _speed * Time.deltaTime;
                    }
                }
                else
                {

                    if (isItAWall == true)
                    {

                        transform.rotation *= Quaternion.Euler(0, 180, 0);
                        transform.position += transform.forward * Time.deltaTime * _speed;
                    }

                    else
                    {

                        transform.position += transform.forward * Time.deltaTime * _speed;
                    }
                }
            }
            else
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            }
            

           

        }

        public void DamageTaken()
        {
            LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._ennemiesTakingDamage);
        }

        public void ReactiveUs()
        {
            gameObject.SetActive(true);
        }

        public void SpawnCadavre()
        {
            Instantiate(_cadavretospawn, _offset.transform.position, _offset.transform.rotation);
            gameObject.SetActive(false);
            _isdead = true;
           
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