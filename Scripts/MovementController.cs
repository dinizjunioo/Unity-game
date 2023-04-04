using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] string name = "din";
    //
    public float movementSpeed = 3.0f;
    //
    Vector2 movement = new Vector2();
    //
    Rigidbody2D rb2D;
    //
    Animator animator;
    //
    String animationState = "AnimationState";

    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        //System.Console.WriteLine("sei lá");
        //Console.WriteLine("seila2");
    }

    // Update is called once per frame
    private void Update()
    {
        updateState();
        //Console.WriteLine("seila2");
    }

    void FixedUpdate()
    {
        moveCharacter();
    }

    private void moveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }
    private void  updateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)
           CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)
           CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)
           CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)
           CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)
           CharStates.idleSouth);
        }
    }
}
