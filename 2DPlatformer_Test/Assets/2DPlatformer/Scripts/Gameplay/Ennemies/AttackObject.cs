namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AttackObject : MonoBehaviour
    {
        // Start is called before the first frame update
        private float _float = 0.2f;
        private bool _lebool = true;

        [SerializeField]
        private ParticleSystem _ParticleSystem = null;


        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void DestroyMePlease()
        {
            _lebool = true;

        }

        private void Update()
        {
            if (transform.rotation == Quaternion.Euler(0, 0, 0))
            {
            
                _ParticleSystem.startRotation = 0;
            }

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

}