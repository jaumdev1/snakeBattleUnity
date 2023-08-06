using UnityEngine;

public class Power : MonoBehaviour, IPower
{
    private int size;
  
    public void UpdatePower()
    {
      
    }
    private void Start()
    {
        size = 1;
    }
    private void Update()
    {
       
        Vector3 nextGridPosition = this.gameObject.transform.position + (this.gameObject.transform.right * 10);
        this.gameObject.transform.position = nextGridPosition;
        
        if(size > 10){
            Object.Destroy(this.gameObject);
        }
        size++;
    }
}
