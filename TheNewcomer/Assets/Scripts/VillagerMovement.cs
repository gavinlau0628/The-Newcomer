using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigibody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public bool canMove;
    private DialogueManager theDM;

	// Use this for initialization
	void Start () {
        myRigibody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        canMove = true;
	}
	

    //NPC can move
	// Update is called once per frame
	void Update () {

        if (!theDM.dialogActive)
        {
            canMove = true;
        }
        
        if(!canMove)
        {
            myRigibody.velocity = Vector2.zero;
            return;
        }
        //moving randomly
        if (isWalking){
            walkCounter -= Time.deltaTime;

            switch(walkDirection){
                case 0:
                    myRigibody.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    myRigibody.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    myRigibody.velocity = new Vector2(0, -moveSpeed);
                    break;

                case 3:
                    myRigibody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        } else {
            waitCounter -= Time.deltaTime;
            myRigibody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;

    }
}
