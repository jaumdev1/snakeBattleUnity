using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{


    private List<Snake> snakeList;
    private LevelGrid levelGrid;
    [SerializeField]
    private GameObject SnakePrefab;

    public static LevelGrid LevelGrid;
    
    private void Start()
    {
        Debug.Log("start!");

        levelGrid = new LevelGrid(100, 50);
        //snake.Setup(levelGrid);

        //snakeList.Add(snake);
        Instantiate(SnakePrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}