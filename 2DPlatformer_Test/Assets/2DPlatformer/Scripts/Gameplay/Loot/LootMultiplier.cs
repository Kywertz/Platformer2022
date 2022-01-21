namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "GameSup/LootMultiplier", fileName = "LootMultiplier")]
    public class LootMultiplier : PickupCommand
    {
        
       
        //[SerializeField]
        private LootManager _lootmanager = null;

        [SerializeField]
        private int _mutliplicator = 2;

        protected override bool ApplyPickup(ICommandSender from)
        {
            _lootmanager = LevelReferences.Instance.LootManager;
            _lootmanager._lootmultiplier = _mutliplicator;
            Debug.Log("LOOT MULTIPLICATED PER : " + _mutliplicator);
            return true;
        }
    }

}