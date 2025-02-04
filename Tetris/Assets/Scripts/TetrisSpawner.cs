using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetrisSpawner : MonoBehaviour
{
    public GameObject[] tetrominoPrefabs;  //Array of Terromino prefabs
    private TetrisGrid grid;  //Reference to the TetrisGrid
    private GameObject nextPiece;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<TetrisGrid>();  //Find the grid instance in the scene
        if (grid == null)
        {
            Debug.LogError("TetrisGrid not found in the scene. Ensure a TetrisGrid object exists.");
            return;
        } 
        SpawnPiece(); //Initial spawn
    }
    public void SpawnPiece()
    {
        //Calculate the top-centre spawn position based on grid dimensions
        Vector3 spawnPosition = new Vector3(Mathf.Floor(grid.width / 2f), grid.height - 1, 0);     
        
        if (nextPiece != null)
        {
            nextPiece.SetActive(true);
            nextPiece.transform.position = spawnPosition;
        }
        else
        {
            nextPiece = InstantiateRandomPiece();
            nextPiece.transform.position = spawnPosition;
        }
        //Prepare the next piece for preview
        nextPiece = InstantiateRandomPiece();
        nextPiece.SetActive(false);  //Deactivate until it's the active piece

    }
    private GameObject InstantiateRandomPiece()
    {
        int index = Random.Range(0, tetrominoPrefabs.Length);
        return Instantiate(tetrominoPrefabs[index]);
    }
    

}
