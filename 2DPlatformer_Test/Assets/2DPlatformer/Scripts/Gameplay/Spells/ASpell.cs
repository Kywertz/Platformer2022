namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class ASpell : MonoBehaviour
    {
        // Start is called before the first frame update
        private InteractWithDamageable _interactWith = InteractWithDamageable.Everything;
        public void SetInteractWith(InteractWithDamageable interactWith)
        {
            _interactWith = interactWith;
        }
    }

}