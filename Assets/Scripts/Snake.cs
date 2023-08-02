using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private void Awake()
    {
        gridPosition = new Vector2Int(0,0);
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(2, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -2) { 
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 2)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 2)
            {
                gridMoveDirection.x = -2;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -2)
            {
                gridMoveDirection.x = 2;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gridMoveTimerMax = 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gridMoveTimerMax = 1f;
        }
      
    }
    private void FixedUpdate()
    {
        gridMoveTimer += Time.fixedDeltaTime;

        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer = 0f;
        }

        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }
}
