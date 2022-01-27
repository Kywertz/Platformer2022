namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class SpellUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text = null;


        private void OnEnable()
        {
            var SpellManager = LevelReferences.Instance.SpellManager;
            SpellManager.SpellAdded -= SpellManagerOnSpellAdded;
            SpellManager.SpellAdded += SpellManagerOnSpellAdded;

            UpdateValues(SpellManager.CurrentSpell);
        }

        private void OnDisable()
        {
            if (LevelReferences.HasInstance == true)
            {
                LevelReferences.Instance.SpellManager.SpellAdded -= SpellManagerOnSpellAdded;
            }
        }

        private void SpellManagerOnSpellAdded(SpellManager sender, int currentLoot)
        {
            UpdateValues(currentLoot);
        }

        private void UpdateValues(int loot)
        {
            _text.text = loot.ToString();
            Debug.Log(loot);

        }
    }
}