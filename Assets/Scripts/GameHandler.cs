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
    private int teste = 0;
    private void Awake()
    {

        
    }

    private void Start()
    {
        Debug.Log("start!");

        levelGrid = new LevelGrid(100, 50);
        Instantiate(SnakePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)).GetComponent<Snake>()
      .Setup(levelGrid);
    

    }

    // Update is called once per frame
    void Update()
    {

        if (teste == 10) { 
        Instantiate(SnakePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)).GetComponent<Snake>()
        .Setup(levelGrid);
        }
        teste++;
    }
    
}