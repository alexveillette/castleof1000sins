using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {
	
	public DialogueScript dialogueBox;

	void OnTriggerStay2D(Collider2D coll)
	{
		if (Input.GetKeyDown("space"))
		{
			dialogueBox = GameObject.Find ("HUD(Clone)").GetComponentInChildren<DialogueScript>();
			
			if (gameObject.tag == "LeftArmor")
			{
				dialogueBox.NewText("I must confess, this place is a mess! You there, care to prevent me from certain madness?");
			}
			else if (gameObject.tag == "RightArmor")
			{
				dialogueBox.NewText("Ohohoho! I may have lost my head, but I'm still willing to solve riddles! After all, two heads are better than one, right?");
			}
			else if (gameObject.tag == "TopArmor")
			{
				dialogueBox.NewText("Grant me the two keys and the curse shall be lifted. Not that it will do the castle much good...");
			}
		}
	}
	
	
	
	
}
