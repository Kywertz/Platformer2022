namespace GSGD2.Gameplay
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using GSGD2.Player;

	public class RespawnAtLatestJump : MonoBehaviour
	{


		[SerializeField]
		private GameObject _microcheckpoint = null;

        private void OnTriggerEnter(Collider other)
        {
			LevelReferences.Instance.Player.transform.position = _microcheckpoint.transform.position;
        }


    }
}