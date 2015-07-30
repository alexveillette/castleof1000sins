using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	/// <summary>
	/// This simple script is found on the SceneManager
	/// game object, and changes scenes depending on what
	/// happens in the game. It also transitions to the 
	/// appropriate music.
	/// </summary>
	public MusicController musicController;
	
	public void SwitchScene(string scene)
	{
		musicController = GameObject.Find ("MusicController").GetComponent<MusicController>();

		if (scene == "titleScreen")
		{
			musicController.Transition(1);
		}
		else if (scene == "castle")
		{
			musicController.Transition(2);
		}
		else if (scene == "winScreen")
		{
			musicController.Transition(3);
		}
		else if (scene == "gameOverScreen")
		{
			musicController.Transition(4);
		}

		Application.LoadLevel (scene);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
