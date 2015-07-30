using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
	/// <summary>
	/// This script is used to handle text fading
	/// when dialogue is displayed. It is strictly
	/// for esthetic purposes. The NewText function takes
	/// a string as parameter, displays the text and fades
	/// it gradually by using a Coroutine.
	/// </summary>
	public static string dialogue;

	private Text text;
	private Color textColor;
	private int textAlpha;

	void Start () 
	{
		text = GetComponent<Text> ();

		textColor.a = 1.0f;
		textColor.r = 255;
		textColor.g = 255;
		textColor.b = 255;
		StartCoroutine (TextDisappear ());
	}

	void Update()
	{
		text.text = dialogue;
	}

	public void NewText(string newText)
	{
		dialogue = newText;
		textColor.a = 1.0f;
		StartCoroutine (TextDisappear ());
	}

	IEnumerator TextDisappear()
	{
		while (textColor.a > 0)
		{
			textColor.a -= 0.002f;
			text.color = textColor;
			yield return null;
		}
	}
}