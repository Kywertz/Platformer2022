namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;
    public class SpellUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text = null;

        [SerializeField]
        private Image _foreground = null;

        //private int _maximumOfSpells = LevelReferences.Instance.SpellManager._maximumofusingspells;

        [SerializeField]
        private Image _background = null;

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
            //test();
            //_text.text = currentLoot.ToString();
            //float perc = Mathf.Clamp01(currentLoot / 5);
            //_foreground.fillAmount = perc;
            //Debug.Log(perc);

        }

        private void UpdateValues(int loot )
        {
            _text.text = loot.ToString();
            float perc = loot / 5;
            _foreground.fillAmount = perc;
            Debug.Log(perc);
            //Debug.Log(loot);

        }


        

        private void test()
        {
            float perc = LevelReferences.Instance.SpellManager._currentspell / LevelReferences.Instance.SpellManager._maximumofusingspells;
            //float perc = Mathf.Clamp01(LevelReferences.Instance.SpellManager._currentspell / LevelReferences.Instance.SpellManager._maximumofusingspells);
            _foreground.fillAmount = perc;
            Debug.Log(perc);
        }
       
    }
}