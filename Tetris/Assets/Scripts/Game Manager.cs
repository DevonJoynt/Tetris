using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public GameObject[] Tetrominos;
    public float movementFrequency = 0.8f;
    private float passedTime = 0;
    private GameObject currentTetromino;
    private bool IsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver == false)
        {
            passedTime += Time.deltaTime;
            if (passedTime >= movementFrequency)
            {
                passedTime -= movementFrequency;
                MoveTetromino(Vector3.down);
            }
            UserInput();
        }
    }
    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTetromino(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTetromino(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentTetromino.transform.Rotate(0, 0, -90);   //Rotate pieces clockwise
            if (!IsValidPosition())
            {
                currentTetromino.transform.Rotate(0, 0, 90);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementFrequency = 0.2f;  //Speed to move down
        }
        else
        {
            movementFrequency = 0.8f;
        }
    }
    void SpawnTetromino()
    {
        int index = Random.Range(0, Tetrominos.Length);
        currentTetromino = Instantiate(Tetrominos[index], new Vector3(5, 17, 0), Quaternion.identity);    //Location at top to spawn in
        CheckGameOver();
    }
    void MoveTetromino(Vector3 direction)
    {
        currentTetromino.transform.position += direction;
        if (!IsValidPosition())
        {
            currentTetromino.transform.position -= direction;
            if (direction == Vector3.down)
            {
                GetComponent<GridScript>().UpdateGrid(currentTetromino.transform);
                CheckForLines();
                SpawnTetromino();
            }
        }
    }
    bool IsValidPosition()
    {
        return GetComponent<GridScript>().IsValidPosition(currentTetromino.transform);
    }
    void CheckForLines()
    {
        GetComponent<GridScript>().CheckForLines();
    }
    void CheckGameOver()
    {
        if (IsValidPosition() == false)
        {
            IsGameOver = true;
            // load screen in unity
        }

    }
}
