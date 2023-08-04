using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Snake snake;
    private LevelGrid levelGrid;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("start!");


        levelGrid = new LevelGrid(20, 20);


        snake.Setup(levelGrid);

        levelGrid.Setup(snake);
    }

    // Update is called once per frame
    void Update()
    {

    }
}