namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Utilities;

    public class LootInstancier : MonoBehaviour
    {
        [SerializeField]
        private PickupInteractor _lootPickup = null;

        // Simplified command for UnityEvent
        public void DoInstantiateLoot() => InstantiateLoot();

        [SerializeField]
        private Transform _transform = null;

        public PickupInteractor InstantiateLoot()
        {
            return GameObject.Instantiate(_lootPickup, _transform.position, _transform.rotation);
        }
    }
}