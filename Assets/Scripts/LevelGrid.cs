using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    public float foodSize = 2.0f;
    private GameObject foodGameObject;
    private Snake snake;
    public void Setup(Snake snake)
    {
        this.snake = snake;
    }
    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        SpawnFood();

    }

    private void SpawnFood()
    {
        int randomColorIndex = Random.Range(0, 2);
        int randomX = Random.Range(0, width);
        int randomY = Random.Range(0, height);
        foodGridPosition = new Vector2Int(randomX - randomX % 2, randomY - randomY % 2);
        //foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        foodGameObject.transform.localScale = new Vector3(foodSize, foodSize, 1f); // Use 1f para evitar problemas de escala no Z.
        Color[] colors = { Color.yellow, Color.blue };
        foodGameObject.GetComponent<SpriteRenderer>().color = colors[randomColorIndex];
        
        // Calcule a posição do centro da célula do grid em coordenadas do mundo.
        Vector3 centerOfCell = new Vector3(foodGridPosition.x, foodGridPosition.y, 0f);

        // Atribua a posição da comida para o centro da célula do grid.
        foodGameObject.transform.position = centerOfCell;

         
    }
    public void SnakeMoved(Vector2Int snakeGridPositon)
    {
        if(snakeGridPositon == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();


        }
    }
}

