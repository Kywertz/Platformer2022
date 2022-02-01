namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    public class Movable : MonoBehaviour
    {
        
        [SerializeField]
        private PhysicsTriggerEvent _physicsTriggerEvent = null;

        private void OnEnable()
        {
            _physicsTriggerEvent._onTriggerStay.RemoveListener(OnTriggerMoveStay);
            _physicsTriggerEvent._onTriggerStay.AddListener(OnTriggerMoveStay);
            _physicsTriggerEvent._onTriggerExit.RemoveListener(OnTriggerMoveExit);
            _physicsTriggerEvent._onTriggerExit.AddListener(OnTriggerMoveExit);
        }

        private void OnDisable()
        {
            _physicsTriggerEvent._onTriggerStay.RemoveListener(OnTriggerMoveStay);
            _physicsTriggerEvent._onTriggerExit.AddListener(OnTriggerMoveExit);

        }

      

        private void OnTriggerMoveStay(PhysicsTriggerEvent physicsTriggerEvent, Collider other)
        {
            MovableController player = other.GetComponentInParent<MovableController>();
            if (player  != null)
            {
                
                player.Add(this);
               
            }
           
        }

        private void OnTriggerMoveExit(PhysicsTriggerEvent physicsTriggerEvent, Collider other)
        {
            MovableController player = other.GetComponentInParent<MovableController>();
            if(player != null)
            {
              player.Remove(this);
              
            }
        }

    }

     
}

