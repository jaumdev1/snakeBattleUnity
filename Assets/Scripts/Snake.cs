using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour, ISnake
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private Queue<Vector2Int> pendingDirections;
    private LevelGrid levelGrid;
    private List<GameObject> Tails;
    private List<IPower> _observers = new List<IPower>();
    [SerializeField]
    private GameObject PowerPrefab;
    public void Attach(IPower observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IPower observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.UpdatePower();
        }
    }



    private Color tailColor = Color.magenta;
    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
        pendingDirections = new Queue<Vector2Int>();

        Tails = new List<GameObject>();
    

    }

    private void Update()
    {
        Inputs();
        Notify();
        
    }

    private void FixedUpdate()
    {
        gridMoveTimer -= Time.fixedDeltaTime;

        if (gridMoveTimer <=0f)
        {


            gridMoveTimer = gridMoveTimerMax;
            //if (Tails.Count > 0)
            //{
            //    var tai = Tails[0];
            //    Tails.Remove(tai);
            //    Destroy(tai);
            //}

            //CreateTailSprite(gridPosition, 0);

            if (pendingDirections.Count > 0)
            {
                gridMoveDirection = pendingDirections.Dequeue();


            }

            UpdateGridPosition();

          

        }


    }

    private void UpdateGridPosition()
    {
        
        Vector2Int nextGridPosition = gridPosition + (gridMoveDirection * 2);
        //transform.position = new Vector3(nextGridPosition.x, nextGridPosition.y, 0f);
        float angle = Mathf.Atan2(gridMoveDirection.y, gridMoveDirection.x) * Mathf.Rad2Deg;

        //angle += 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        gridPosition = nextGridPosition;
        this.gameObject.transform.position = new Vector3(nextGridPosition.x, nextGridPosition.y);
        

         bool SnakeAte =  levelGrid.TryEatFoodSnakeMoved(gridPosition);
        if (SnakeAte)            
            CreateTailSprite(gridPosition, 1);

            

     

    }
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                pendingDirections.Enqueue(new Vector2Int(0, 1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                pendingDirections.Enqueue(new Vector2Int(0, -1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                pendingDirections.Enqueue(new Vector2Int(-1, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                pendingDirections.Enqueue(new Vector2Int(1, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gridMoveTimerMax = 0.01f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            gridMoveTimerMax = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Power();
        }
    }


    private void CreateTailSprite(Vector2 position, int x)
    {
             
      

        Vector3 positionVector = new Vector3(position.x, position.y, 0f);
        Vector3 scale = Vector3.one * 0.5f;
        Color color = Color.white;


        var tail = FunctionTime.Create(positionVector, scale, gridMoveTimerMax, x);
        Tails.Add(tail);
    }


    public void Power()
    {
        Vector3 position = new Vector3(gridPosition.x, gridPosition.y, 0f);
        FunctionTime.CreatePower(position, this.transform.rotation, PowerPrefab);
    }
}