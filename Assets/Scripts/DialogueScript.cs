using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

	public static string dialogue;

	private Text text;
	private Color textColor;
	private int textAlpha;

	void Start () {
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