namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaterLostSpellOnTime : MonoBehaviour
    {
        [SerializeField]
        private int _SpellULost = 1;

        [SerializeField]
        private float _secondoflostspells = 1f;

        private bool _isenter = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other = LevelReferences.Instance.Player.Collider)
            {
                Debug.Log("Enter");
                _isenter = true;
            }
            else
            {
                print( "pas le player");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other = LevelReferences.Instance.Player.Collider)
            {
                Debug.Log("Stay");
                _isenter = true;
                if (_secondoflostspells < 0)
                {
                    _secondoflostspells = 1f;
                }
            }
            else
            {
                print("pas le player");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other = LevelReferences.Instance.Player.Collider)
            {
                Debug.Log("Exit");
                _isenter = false;
            }
            else
            {
                print("pas le player");
            }
        }

        private void Update()
        {

            Debug.LogFormat("{0},{1}", _isenter, _secondoflostspells);

            if (_isenter == true)
            {
                _secondoflostspells -= Time.deltaTime;
            }
            if (_secondoflostspells < 0)
            {
                LevelReferences.Instance.SpellManager.UsingSpell(_SpellULost);
            }
            
        }

    }

}