using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{

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