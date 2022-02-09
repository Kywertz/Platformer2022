namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LifeManager : MonoBehaviour
    {

        //[SerializeField]
        //private GameObject[] _hearts = null;

        private Damageable _damageable;

        private void Awake()
        {
            _damageable = LevelReferences.Instance.Player.GetComponent<Damageable>();
        }


      

    }

}