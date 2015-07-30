using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	/// <summary>
	/// This script handles the HUD display of the
	/// number of soul essences the player has acquired.
	/// </summary>

	public static int score;
	public static int levelNumber;

	private Text scoreText;

	void Start () 
	{
		scoreText = GetComponent<Text>();
		score = 0;
		levelNumber = 20;
	}

	void Update () 
	{
		scoreText.text = "Soul Essences: " + score + "/" + levelNumber;
	}
}