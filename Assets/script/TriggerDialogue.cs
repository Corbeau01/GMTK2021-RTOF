using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
	public DialogueManager.Dialogue DialogueToTrigger;

	public bool Triggered;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (Triggered)
			return;
		Triggered = true;
		if (DialogueManager.Instance != null)
			DialogueManager.Instance.StartDialogue(DialogueToTrigger);
	}
}
