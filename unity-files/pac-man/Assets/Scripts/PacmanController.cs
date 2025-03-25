using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacmanController : MonoBehaviour
{
    private enum MovementDirections
    {
        up = 0,
        right,
        down,
        left
    }
    // direction Pac-Man is currently moving in
    private MovementDirections currentDirection;
    // stores direction Pac-Man will move in after next intersection
    private MovementDirections nextDirection;
    
    private Vector2 directionVector;

    [SerializeField] private int movementSpeed;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        // Searches for Pac-Man's rigidbody2D
        if (!TryGetComponent<Rigidbody2D>(out rb))
        {
            // If unsuccessful, logs an error
            Debug.LogError("Could not find Pac-Man's Rigidbody2D.");
        }
    }
    // Update is called once per frame
    private void Update()
    {
        GetMovementInput();
        GetNearbyTileInfo();
    }

    private void FixedUpdate()
    {
        // rb.MovePosition(transform.position + nextDirection)
        Vector2 changeInPos = directionVector * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition((Vector2)transform.position + changeInPos);
    }

    // Pac-Man movement input detection:
    // if (input)
    //      if (intersection is one tile or less in front of pac-man) ----// perhaps two tiles? needs testing
    //          accept input and pass as direction to use from intersection
    //          // perhaps need currentDirection and nextDirection,
    //              possibly in a queue but that may be overdoing it for 2 values

    private void GetMovementInput()
    {
        // directionVector is NOT reset or set to zero when there is no input.
        // Pac-Man will continue in this direction until collision or different input
        float movementVertical = Input.GetAxisRaw("Vertical");
        float movementHorizontal = Input.GetAxisRaw("Horizontal");

        if      (movementVertical   >  0.01f) directionVector = Vector2.up;
        else if (movementVertical   < -0.01f) directionVector = Vector2.down;
        else if (movementHorizontal >  0.01f) directionVector = Vector2.right;
        else if (movementHorizontal < -0.01f) directionVector = Vector2.left;
    }

    private void GetNearbyTileInfo()
    {
        // returns info about adjacent tiles (not diagonal)
        // Info would allow the following logic:
        //      e.g. if (!tile.isPath) DoNotAllowMoveThere()
    }

}


