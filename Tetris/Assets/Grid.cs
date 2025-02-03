using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int width = 10;
    public int height = 20;
    private Transform[,] grid;


    // Start is called before the first frame update
    void Start()
    {
        grid = new Transform[width, height];
    }

    public bool IsCellOccupied(Vector2Int position)
    {
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height)
        {
            return true;   //Out of bounds
        }
        return grid[position.x, position.y] != null;
    }

    
    public void AddToGrid(Transform piece)
    {
        foreach (Transform block in piece)
        {
            Vector2Int position = Vector2Int.RoundToInt(block.position);
            grid[position.x, position.y] = block;
        }
    }
    
        
    
}
