using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Animator animator;
    private Rigidbody2D myRigibody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;

    public string startPoint;

    public bool canMove;


    // Use this for initialization
    void Start()
    {
        //if no player exists in map, dont destory it
        animator = GetComponent<Animator>();
        myRigibody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject); 
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerMoving = false;

        if(!canMove)
        {
            myRigibody.velocity = Vector2.zero;
            return;
        }

        //left and right checker
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime,0f,0f));
            myRigibody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigibody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        //up and down checker
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate (new Vector3 (0f,Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime,0f));
            myRigibody.velocity = new Vector2(myRigibody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigibody.velocity = new Vector2(0f, myRigibody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigibody.velocity = new Vector2(myRigibody.velocity.x, 0f);
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }
}

