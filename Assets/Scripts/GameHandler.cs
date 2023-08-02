using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private LevelGrid levelGrid;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start!");

        GameObject snakeHeadGameObject = new GameObject();

        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        snakeSpriteRenderer.sprite = GameAssets.instance.snakeHeadSprite;

        levelGrid = new LevelGrid(25, 25);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
