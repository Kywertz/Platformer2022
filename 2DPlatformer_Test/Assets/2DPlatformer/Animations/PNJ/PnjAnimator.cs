namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PnjAnimator : MonoBehaviour
    {

        //[SerializeField]
        //private GameObject _rig = null;

        [SerializeField]
        private Animator _animator = null;

        //[SerializeField]
        //private Damageable _damageableoftheplayer = null;

        //[SerializeField]
        //private GameObject _ennemiePrefab = null;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {
                _animator.SetTrigger("Attack");
                //_damageableoftheplayer.TakeDamage();
                _stopmoving = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {
                _animator.SetTrigger("EndAttack");
                _stopmoving = false;
            }
        }

        public void Dead()
        {
            print("Dead");
            _animator.SetTrigger("Dead");
           
            _stopmoving = true;
            _isdead = true;
        }


        private void Update()
        {

            

            if (_isdead == true)
            {
                
                print("Dead true");
                _timeofanimation -= Time.deltaTime;
            }

            if (_timeofanimation == 0 || _timeofanimation < 0)
            {
                print("spawn");
                _ennemie.SpawnCadavre();
            }
        }
    }

}