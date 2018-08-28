using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;


	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //when it is triggered, show active the dialogue
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dMAn.ShowBox(dialogue);

                if(!dMAn.dialogActive)
                {
                    dMAn.dialogueLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }

                if(transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
} 
