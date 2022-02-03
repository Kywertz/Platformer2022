namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PnjAnimator : MonoBehaviour
    {

        [SerializeField]
        private GameObject _rig = null;

        [SerializeField]
        private Animator _animator = null;

        [SerializeField]
        private Ennemies _ennemie = null;

        private bool _isdead = false;

        public bool _stopmoving = false;

        [SerializeField]
        private float _timeofanimation = 3f;

        // Start is called before the first frame update
        private void Awake()
        {

        }


        public void Dead()
        {
            print("Dead");
            _animator.SetTrigger("Dead");
            //_rig.transform.position = new Vector3(0,0,gameObject.transform.position.z);
            _stopmoving = true;
            _isdead = true;
        }


        private void Update()
        {

            _rig.transform.position = /*new Vector3(0, 0, 0);*/ _ennemie.gameObject.transform.position;

            if (_isdead == true)
            {
                
                print("Dead true");
                _timeofanimation -= Time.deltaTime;
            }

            if (_timeofanimation < 0)
            {
                print("spawn");
                _ennemie.SpawnCadavre();
            }
        }
    }

}