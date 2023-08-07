using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGrid
{

    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    public float foodSize = 2.0f;
    public List<GameObject> foodList;  


    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.foodList = new List<GameObject>();
        var i = 0;
        while (i < 10)
        {
            SpawnFood();
            i++;
        }
        
   

    }

    private void SpawnFood()
    {
        GameObject foodGameObject;
        int randomColorIndex = Random.Range(0, 2);
        int randomX = Random.Range(-100, width);
        int randomY = Random.Range(-50, height);
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
        foodList.Add(foodGameObject);


    }
    public bool TryEatFoodSnakeMoved(Vector2Int snakeGridPosition)
    {

        var food = foodList.Where(p => p.transform.position.x == snakeGridPosition.x && p.transform.position.y == snakeGridPosition.y).SingleOrDefault();
        if (food != null)
        {
            foodList.Remove(food);
            Object.Destroy(food);

            SpawnFood();
            return true;

        }
        else
        {
            return false;
        }

    }
  

    

}

