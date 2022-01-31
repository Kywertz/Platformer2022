namespace GSGD2.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using GSGD2.Player;
	/// <summary>
	/// Player version of <see cref="AKillZoneReceiver"/>
	/// </summary>
	public class PlayerKillzoneReceiver : AKillZoneReceiver
	{
		[SerializeField]
		private CubeController _cubecontroller = null;

		public override void OnEnterKillzone(Killzone killzone)
		{
            LevelReferences.Instance.PlayerStart.ResetPlayerPosition();

        }
    }
}