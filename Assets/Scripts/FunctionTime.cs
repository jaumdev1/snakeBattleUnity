using System.Collections;
using UnityEngine;

public class FunctionTime : MonoBehaviour
{
	public static GameObject Create(Vector3 position, Vector3 scale, float destroyTime, int x)
	{
		GameObject spriteObject = new GameObject("Tail"+x);
		SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();

		// Cria um sprite roxo programaticamente
		Texture2D purpleTexture = new Texture2D(40, 40);
		Color[] purplePixels = purpleTexture.GetPixels();
		for (int i = 0; i < purplePixels.Length; i++)
		{
			purplePixels[i] = Color.green;
		}

		purpleTexture.SetPixels(purplePixels);
		purpleTexture.Apply();

		Sprite purpleSprite = GameAssets.instance.bodySprite;
        
        spriteRenderer.sprite = purpleSprite;
		spriteRenderer.transform.position = position;
		spriteRenderer.transform.localScale = scale;
        return spriteObject;
	}
    public static void CreatePower(Vector3 positionHead, Quaternion quartenion, GameObject power)
    {
	

		Instantiate(power, positionHead, quartenion);
   
    }

}