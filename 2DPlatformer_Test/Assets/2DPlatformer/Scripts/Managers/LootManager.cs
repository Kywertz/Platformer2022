namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class LootManager : MonoBehaviour
    {
        private int _currentLoot = 0;
        public int _lootmultiplier = 1;
        public int CurrentLoot => _currentLoot;

        public delegate void LootManagerEvent(LootManager sender, int currentLoot);
        public event LootManagerEvent LootAdded = null;

        public void AddLoot(int value)
        {
            _currentLoot += value * _lootmultiplier;

            LootAdded?.Invoke(this, _currentLoot);
        }

        public void RemoveLoot(int value)
        {
            if(_currentLoot > 0)
            {
               _currentLoot -= value;
               LootAdded?.Invoke(this, _currentLoot);
                
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