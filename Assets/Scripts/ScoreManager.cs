using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{

	public static int score;

	Text text;

	void Start () 
	{
		text = GetComponent<Text>();
		score = 0;
	}
	

	void Update () 
	{
		text.text = "Score: " + score;
	}
}