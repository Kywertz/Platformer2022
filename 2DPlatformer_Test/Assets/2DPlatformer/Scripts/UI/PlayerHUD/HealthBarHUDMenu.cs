namespace GSGD2.UI
{
    using GSGD2.Gameplay;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Subsystem that handle the player health bar. It seek player <see cref="Damageable"/>, listen to its <see cref="Damageable.DamageTaken"/>  and <see cref="Damageable.HealthRestored"\> event and react accordingly.
    /// </summary>
    public class HealthBarHUDMenu : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] _hearts = null;

        private Damageable _damageable = null;

        private void Awake()
        {
            _damageable = LevelReferences.Instance.Player.GetComponent<Damageable>();
        }

        private void OnEnable()
        {
            if (_damageable != null)
            {
                _damageable.DamageTaken -= Damageable_OnHealthChanged;
                _damageable.DamageTaken += Damageable_OnHealthChanged;
                _damageable.HealthRestored -= Damageable_OnHealthChanged;
                _damageable.HealthRestored += Damageable_OnHealthChanged;

            }
        }

        private void OnDisable()
        {
            if (_damageable != null)
            {
                _damageable.DamageTaken -= Damageable_OnHealthChanged;
                _damageable.HealthRestored -= Damageable_OnHealthChanged;
            }
        }

        private void Start()
        {
            if (_damageable != null)
            {
                UpdateHealth(_damageable.CurrentHealth, _damageable.MaxHealth);
            }
        }

        private void Damageable_OnHealthChanged(Damageable sender, Damageable.DamageableArgs args)
        {
            UpdateHealth(args.currentHealth, args.maxHealth);
        }

        private void UpdateHealth(float health, float maxHealth)
        {

            for (int i = 0; i < _hearts.Length; i++)
            {
                if ((health - 1) >= i)
                {
                    _hearts[i].SetActive(true);
                }
                else
                {
                    _hearts[i].SetActive(false);
                }
            }
        }

    }
}