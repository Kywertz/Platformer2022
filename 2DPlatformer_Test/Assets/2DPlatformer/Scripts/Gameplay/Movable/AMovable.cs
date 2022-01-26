namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    public abstract class AMovable : MonoBehaviour
    {
        //Contenue de ma classe abstraite qu'est qu'on tous les movable du jeu ?
        //Peuvent ils bouger ?
        public bool _canmove = false;

        private void OnTriggerEnter(Collider other)
        {
            if ((other.GetComponentInParent<PlayerReferences>() == true))
            {
                _canmove = true;
            }
        }

        private void CanMove()
        {

            if (_canmove == false)
            {
                this.gameObject.transform.position = transform.position;
            }

        }

        private void Update()
        {
            CanMove();
        }
    }

}