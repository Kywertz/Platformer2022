namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    public class EnterOnWater : MonoBehaviour
    {
        private bool _isenter = false;
        private float _time = 2f;

        [SerializeField]
        private int _intlosepersecondsonwater = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other == LevelReferences.Instance.Player.Collider)
            {
                _isenter = true;
            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (_time < 0)
            {
                _time = 2f;
            }
        }


        private void Update()
        {
            if (_isenter == true)
            {
                _time -= Time.deltaTime;
            }

            if (_time < 0)
            {
                LevelReferences.Instance.SpellManager.UsingSpell(_intlosepersecondsonwater);
            }
        }

    }

}