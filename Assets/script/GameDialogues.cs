using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueManager;

[CreateAssetMenu(fileName = "GameDialogues", menuName = "GMTK2021-RTOF/GameDialogues", order = 0)]
public class GameDialogues : ScriptableObject
{

	[NamedList(typeof(Dialogue))]
	public DialogueData[] Dialogues;
}
