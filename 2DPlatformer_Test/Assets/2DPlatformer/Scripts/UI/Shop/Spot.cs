namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.EventSystems;

    public class Spot : MonoBehaviour
    {
        [SerializeField]
        private ShopUi _shopui = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<PlayerReferences>() == true)
            {
                _shopui.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInParent<PlayerReferences>() == true)
            {
                _shopui.gameObject.SetActive(false);

            }
        }
    }


}