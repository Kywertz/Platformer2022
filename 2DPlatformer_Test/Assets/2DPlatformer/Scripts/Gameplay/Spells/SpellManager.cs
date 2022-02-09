namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    public class SpellManager : MonoBehaviour
    {
        public int _currentspell = 5;

        private int _utilisationsofspells = 0;

        [SerializeField]
        private Image _forground = null;

        public  int _maximumofusingspells = 5;
        public int CurrentSpell => _currentspell;

        public delegate void SpellManagerEvent(SpellManager sender, int currentLoot);

        public event SpellManagerEvent SpellAdded = null;

        public void AddSpell(int value)
        {
            if(_utilisationsofspells < _maximumofusingspells && _utilisationsofspells != _maximumofusingspells && _currentspell != 5)
            {
                _currentspell += value ;
                 SpellAdded?.Invoke(this, _currentspell);
                _forground.fillAmount += 0.2f;
            }

        }

        public void ReloadSpells()
        {
            _utilisationsofspells = 0;
            _currentspell = 5;
            SpellAdded?.Invoke(this, _currentspell);
            Debug.Log("Set Spells utilisation to 0 so u can use spells");
            _forground.fillAmount = 1f;
        }

        public void UsingSpell(int value)
        {
            if (_currentspell > 0 && _currentspell != 0)
            {
                _currentspell -= value;
                SpellAdded?.Invoke(this, _currentspell);
                _utilisationsofspells ++;
                _forground.fillAmount -= 0.2f;
            }
        }

       
    }
}