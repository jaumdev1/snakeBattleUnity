using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public Vector2Int foodGridPosition;
    private int width;
    private int height;
    public float foodSize = 1.0f;
    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        SpawnFood();
    }

    private void SpawnFood()
    {
        int randomX = Random.Range(0, width);
        int randomY = Random.Range(0, height);
        foodGridPosition = new Vector2Int(randomX - randomX % 2, randomY - randomY % 2);
        //foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        foodGameObject.transform.localScale = new Vector3(foodSize, foodSize, 1f); // Use 1f para evitar problemas de escala no Z.

        // Calcule a posição do centro da célula do grid em coordenadas do mundo.
        Vector3 centerOfCell = new Vector3(foodGridPosition.x, foodGridPosition.y, 0f);

        // Atribua a posição da comida para o centro da célula do grid.
        foodGameObject.transform.position = centerOfCell;
    }
}
