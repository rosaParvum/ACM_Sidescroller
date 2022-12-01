using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour 
{

	TMP_Text txt;
	string story;

	void Awake () 
	{
		txt = GetComponent<TMP_Text> ();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (0.025f);
		}
	}

}
