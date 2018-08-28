using System.Collections;

using UnityEngine;


public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager theDM;

    // Use this for initialization
    void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //quest will have lines to show in dialog box
    public void ShowQuestText(string questText)
    {
        theDM.dialogueLines = new string[1];
        theDM.dialogueLines[0] = questText;

        theDM.currentLine = 0;
        theDM.ShowDialogue();
    }
}
