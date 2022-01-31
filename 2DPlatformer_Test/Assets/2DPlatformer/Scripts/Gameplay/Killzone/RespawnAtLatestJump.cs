namespace GSGD2.Gameplay
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Component that call <see cref="AKillZoneReceiver.OnEnterKillzone(Killzone)"/> on any <see cref="AKillZoneReceiver"/> that enter its trigger.
	/// </summary>
	[RequireComponent(typeof(Rigidbody))]
	public class RespawnAtLatestJump : Killzone
	{
	}
}