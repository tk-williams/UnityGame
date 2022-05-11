using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Variables
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();

    // Strings
    string animationState = "AnimationState";

    // Components
    Animator animator;
    Rigidbody2D rb2D;

    // CharacterStates contains enumerations of character movement animations corrisponding to the set values of Animator parameter AnimationState
    enum CharacterStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The player is walking.");
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStates();
    }

    void FixedUpdate()
    {
        MoveCharater();
    }

    // MoveCharacter adjusts the movement vector for the character sprite
    private void MoveCharater()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    // UpdateStates adjusts character animations based on the direction of movement
    private void UpdateStates()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharacterStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharacterStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharacterStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharacterStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharacterStates.idleSouth);
        }
    }
}

