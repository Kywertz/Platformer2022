namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class SpellManager : MonoBehaviour
    {
        private int _currentspell = 5;

        private int _utilisationsofspells = 0;

        [SerializeField]
        private int _maximumofusingspells = 5;
        public int CurrentSpell => _currentspell;

        public delegate void SpellManagerEvent(SpellManager sender, int currentLoot);

        public event SpellManagerEvent SpellAdded = null;

        public void AddSpell(int value)
        {
            if(_utilisationsofspells < _maximumofusingspells && _utilisationsofspells != _maximumofusingspells && _currentspell != 5)
            {
                _currentspell += value ;
                 SpellAdded?.Invoke(this, _currentspell);
            }

        }

        public void ReloadSpells()
        {
            _utilisationsofspells = 0;
            _currentspell = 5;
            SpellAdded?.Invoke(this, _currentspell);
            Debug.Log("Set Spells utilisation to 0 so u can use spells");
        }

        public void UsingSpell(int value)
        {
            if (_currentspell > 0 && _currentspell != 0)
            {
                _currentspell -= value;
                SpellAdded?.Invoke(this, _currentspell);
                _utilisationsofspells ++;
            }
        }

        //public void MultiplicateLoot(int value)
        //{
        //    //value = _currentLoot * 2;
        //    //LootAdded?.Invoke(this, value);
        //    AddLoot(_currentLoot = value * 2);
        //}
    }
}