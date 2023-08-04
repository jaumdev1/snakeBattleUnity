using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private Queue<Vector2Int> pendingDirections;
    private LevelGrid levelGrid;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(2, 0);
        pendingDirections = new Queue<Vector2Int>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -2)
            {
                pendingDirections.Enqueue(new Vector2Int(0, 2));
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 2)
            {
                pendingDirections.Enqueue(new Vector2Int(0, -2));
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 2)
            {
                pendingDirections.Enqueue(new Vector2Int(-2, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -2)
            {
                pendingDirections.Enqueue(new Vector2Int(2, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gridMoveTimerMax = 0.05f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            gridMoveTimerMax = 0.1f;
        }
    }

    private void FixedUpdate()
    {
        gridMoveTimer += Time.fixedDeltaTime;

        if (gridMoveTimer >= gridMoveTimerMax)
        {
            if (pendingDirections.Count > 0)
            {
                gridMoveDirection = pendingDirections.Dequeue();
            }

            UpdateGridPosition();
            gridMoveTimer -= gridMoveTimerMax;
            
        }
    }

    private void UpdateGridPosition()
    {
        Vector2Int nextGridPosition = gridPosition + gridMoveDirection;
        transform.position = new Vector3(nextGridPosition.x, nextGridPosition.y, 0f);
        gridPosition = nextGridPosition;
        levelGrid.SnakeMoved(gridPosition);
    }
}