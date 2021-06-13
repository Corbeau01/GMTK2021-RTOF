using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{

	[NamedList(typeof(Dialogue))]
	public DialogueData[] Dialogues;

	Queue<Dialogue> _dialogueQueue = new Queue<Dialogue>();
	bool IsInDialogue;

	public enum Dialogue { D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12 }
	// -------------------------------------------

	private void Start()
	{
		StartDialogue(Dialogue.D1);
		StartDialogue(Dialogue.D2);
	}

	private void Update()
	{
		if (IsInDialogue || _dialogueQueue.Count == 0)
			return;

		IsInDialogue = true;

		var nextDialogue = Dialogues[(int)_dialogueQueue.Dequeue()];
		StartCoroutine(DoDialogue(nextDialogue));
	}

	// -------------------------------------------
	public void StartDialogue(Dialogue dialogueToTrigger)
	{
		_dialogueQueue.Enqueue(dialogueToTrigger);
	}

	private IEnumerator DoDialogue(DialogueData dialogueData)
	{
		IsInDialogue = true;
		yield return null;
		print("Je fais " + dialogueData.Bubbles.Length);

		yield return null;
		IsInDialogue = false;

	}
	// -------------------------------------------
	[System.Serializable]
	public struct DialogueData
	{
		public GameObject[] Bubbles;
		public bool AnyKeyToContinue;
	}
}
