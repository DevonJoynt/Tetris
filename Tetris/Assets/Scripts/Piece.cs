using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Piece : MonoBehaviour
{
    private TetrisGrid grid;
    private float dropInterval = 1.0f;  //time between automatic drops
    private float dropTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<TetrisGrid>();
        dropTimer = dropInterval;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();   //handle player input
        HandleAutomaticDrop();  //Automatically move down
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(Vector3.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Move(Vector3.down);
        if (Input.GetKeyDown(KeyCode.Space)) RotatePiece();
       
    }
    private void HandleAutomaticDrop()
    {
        dropTimer -= Time.deltaTime;

        if (dropTimer <= 0)
        {
            Move(Vector3.down);
            dropTimer = dropInterval;  //Reset the timer
        }
    }
    private void Move(Vector3 direction)
    {
        transform.position += direction;

        if (!IsValidPosition())
        {
            transform.position -= direction;  //Revert the move if invalid

            if (direction == Vector3.down)   // If moving down fails
            {
                LockPiece();  //lock the piece in plave
            }


        }
    }
    private void LockPiece()
    {
        
        grid.AddToGrid(transform);  //Put the piece on the grid

        grid.ClearFullLines();  //Check and clear any lines
        FindObjectOfType<TetrisSpawner>().SpawnPiece();  //Give the player a new piece
        Destroy(this);  //Get rid of this script
    }
    private void RotatePiece()
    {
        transform.Rotate(0, 0, 90);

        if (!IsValidPosition())
        {
            transform.Rotate(0, 0, -90); //Revert rotation if invalid
        }
    }
    private bool IsValidPosition()
    {
        foreach (Transform block in transform)
        {
            Vector2Int position = Vector2Int.RoundToInt(block.position);

            if (grid.IsCellOccupied(position))
            {
                return false;  //Blocked or out of bounds
            }
        }
        return true; //Valid position
    }
}
