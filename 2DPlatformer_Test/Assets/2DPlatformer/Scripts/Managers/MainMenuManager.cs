﻿namespace GSGD2.Utilities
{
	using System.Collections;
	using UnityEngine;
#if UNITY_EDITOR
	using UnityEditor;
#endif // UNITY_EDITOR

	/// <summary>
	/// Quick class used to handle MainMenu scene.
	/// </summary>
	public class MainMenuManager : MonoBehaviour
	{
        private void Awake()
        {
			LevelReferences.Instance.SoundManager.PlaySound(LevelReferences.Instance.SoundManager._MenuTheme);
		}

        public void Quit()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif //UNITY_EDITOR
		}
	}
}