using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{

	public Image DialogueImage;
	public AudioSource AudioSource;
	public GameDialogues GameDialogues;

	Queue<Dialogue> _dialogueQueue = new Queue<Dialogue>();
	bool IsInDialogue;
	public float DialogueMinTime;

	public enum Dialogue { D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12 }
	// -------------------------------------------

	private void Start()
	{
		StartDialogue(Dialogue.D1);
	}

	private void Update()
	{
		if (IsInDialogue || _dialogueQueue.Count == 0)
			return;

		IsInDialogue = true;

		var nextDialogue = GameDialogues.Dialogues[(int)_dialogueQueue.Dequeue()];
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

		foreach (var line in dialogueData.Lines)
		{
			float t = 0;

			DialogueImage.gameObject.SetActive(line.Bubble != null);
			DialogueImage.sprite = line.Bubble;

			if (line.Clip != null)
			{
				AudioSource.clip = line.Clip;
				AudioSource.Play();
			}

			var usetimer = !dialogueData.AnyKeyToContinue || line.Bubble == null;
			while ((!dialogueData.AnyKeyToContinue || !Input.anyKeyDown) && (!usetimer || t < DialogueMinTime))
			{
				yield return null;
				t += Time.deltaTime;
			}
			
			yield return null;
		}

		DialogueImage.gameObject.SetActive(false);
		IsInDialogue = false;

	}
	// -------------------------------------------
	[System.Serializable]
	public struct DialogueData
	{
		public DialogueLineData[] Lines;
		public bool AnyKeyToContinue;
	}
	[System.Serializable]
	public struct DialogueLineData
	{
		public Sprite Bubble;
		public AudioClip Clip;
	}
}
