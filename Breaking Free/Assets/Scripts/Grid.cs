using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; x < width; x++)
            {
                Debug.Log(x + ", " + y);

            }
        }

    }

    private Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private Vector2 getXY(Vector3 worldPos)
    {
        int tempX = Mathf.FloorToInt(worldPos.x / cellSize);
        int tempY = Mathf.FloorToInt(worldPos.x / cellSize);
        return new Vector2(tempX, tempY);
    }

    

}
