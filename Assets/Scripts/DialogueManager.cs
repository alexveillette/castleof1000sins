using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {
	/// <summary>
	/// This small script handles game dialogue.
	/// When called upon, it chooses the right translation
	/// and displays the correct text on-screen.
	/// </summary>
	public DialogueScript dialogueBox;
	public Localizater localizater;

	void OnTriggerStay2D(Collider2D coll)
	{
		if (Input.GetKeyDown("space"))
		{

			dialogueBox = GameObject.Find ("HUD(Clone)").GetComponentInChildren<DialogueScript>();
			localizater = GameObject.Find ("LanguageManager").GetComponent<Localizater>();

			if (gameObject.tag == "LeftArmor")
			{
				dialogueBox.NewText (localizater.IDToWord("LEFT"));
			}
			else if (gameObject.tag == "RightArmor")
			{
				dialogueBox.NewText (localizater.IDToWord("RIGHT"));
			}
			else if (gameObject.tag == "TopArmor")
			{
				dialogueBox.NewText (localizater.IDToWord("LAST"));
			}
		}
	}
	
	
	
	
}
