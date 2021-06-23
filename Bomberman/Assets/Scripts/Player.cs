using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public bool player1;
    public bool player2;
    public bool isStoped = false;

    private bool canMove = false;
    private bool buttonBomb;

    public Transform sensor;

    public GameObject Bomb;
    public GameObject PlayerDeathEffect;

    public float sensorSize;

    public int moveSpeed;    
    public int fireLength;
    public int allowedBombs;

    public LayerMask WallLayer;

    private Direction direction;
    private List<Direction> pressedKeys;

    enum Direction
    {
        up = 8,
        left = 4,
        right = 6,
        down = 2
    }

    enum PowerUps
    {
        fireLength = 0,
        addSpeed,
        addBombs
    }

    private void Start()
    {
        pressedKeys = new List<Direction>();
    }
    void Update()
    {
        if (!isStoped) {
            GetInput();
            SetDirection();
            MoveSensor();
            PlantBomb();
            Move();
            
            PlayerAnimation();
        }
     
        UpdateTextInfo();
    }
    private void GetInput()
    {
        GetPressedButtons();
        RemoveUnpressedButtons();

        buttonBomb = Input.GetKeyDown(KeyCode.E)           && player1 || 
                     Input.GetKeyDown(KeyCode.KeypadEnter) && player2;
    }

    private void GetPressedButtons()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && player2 ||
            Input.GetKeyDown(KeyCode.D) && player1)
            pressedKeys.Insert(0, Direction.right);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && player2 ||
            Input.GetKeyDown(KeyCode.A) && player1)
            pressedKeys.Insert(0, Direction.left);
        if (Input.GetKeyDown(KeyCode.DownArrow) && player2 ||
            Input.GetKeyDown(KeyCode.S) && player1)
            pressedKeys.Insert(0, Direction.down);
        if (Input.GetKeyDown(KeyCode.UpArrow) && player2 ||
            Input.GetKeyDown(KeyCode.W) && player1)
            pressedKeys.Insert(0, Direction.up);
    }

    private void RemoveUnpressedButtons()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) && player2 ||
           Input.GetKeyUp(KeyCode.D) && player1)
            pressedKeys.Remove(Direction.right);
        if (Input.GetKeyUp(KeyCode.LeftArrow) && player2 ||
            Input.GetKeyUp(KeyCode.A) && player1)
            pressedKeys.Remove(Direction.left);
        if (Input.GetKeyUp(KeyCode.DownArrow) && player2 ||
            Input.GetKeyUp(KeyCode.S) && player1)
            pressedKeys.Remove(Direction.down);
        if (Input.GetKeyUp(KeyCode.UpArrow) && player2 ||
            Input.GetKeyUp(KeyCode.W) && player1)
            pressedKeys.Remove(Direction.up);
    }

    private void SetDirection()
    {
        if (pressedKeys.Count == 0)
        {
            direction = 0;
            return;
        }

        switch (pressedKeys[0])
        {
            case Direction.up:
                direction = Direction.up;
                break;
            case Direction.left:
                direction = Direction.left;
                break;
            case Direction.down:
                direction = Direction.down;
                break;
            case Direction.right:
                direction = Direction.right;
                break;
        }        
    }

    private void MoveSensor()
    {
        sensor.transform.localPosition = new Vector2(0, 0);
        switch (direction)
        {
            case Direction.up:
                sensor.transform.localPosition = new Vector2(0, sensorSize);
                break;
            case Direction.right:
                sensor.transform.localPosition = new Vector2(sensorSize, 0);
                break;
            case Direction.left:
                sensor.transform.localPosition = new Vector2(-sensorSize, 0);
                break;
            case Direction.down:
                sensor.transform.localPosition = new Vector2(0, -sensorSize);
                break;
            
        }
        canMove = !Physics2D.OverlapBox(sensor.position, new Vector2(sensorSize, sensorSize), 0, WallLayer);
    }

    private void Move()
    {
        if (!canMove) 
            return;
        switch (direction)
        {
            case Direction.down:
                transform.position = VerticalMove(-1);
                break;            
            case Direction.left:
                transform.position = HorizontalMove(-1);
                break;
            case Direction.right:
                transform.position = HorizontalMove(1);
                break;
            case Direction.up:
                transform.position = VerticalMove(1);
                break;
        }
    }


    private Vector2 HorizontalMove(int dx) 
        => new Vector2(transform.position.x + dx * moveSpeed * Time.deltaTime, Mathf.Round(transform.position.y));

    private Vector2 VerticalMove(int dy) 
        => new Vector2(Mathf.Round(transform.position.x), transform.position.y + dy * moveSpeed * Time.deltaTime);



    public void AddSpeed()
    {
        moveSpeed++;
    }

    public void PlantBomb()
    {        
        int plantedBombs = FindAmountOfBombs();
        if (buttonBomb && plantedBombs < allowedBombs)
        {  
            Instantiate(Bomb, new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), transform.rotation);
            FindObjectOfType<Bomb>().creator = this;
        }
    }

    private int FindAmountOfBombs()
    {
        int number = 0;
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (var bomb in bombs)
        {
            if (bomb.creator == this)
            {
                number++;
            }
        }
        return number;
    }


    private void UpdateTextInfo()
    {
        int currentAllowedBombs = allowedBombs - FindAmountOfBombs();
        if (player1 && player2)
            GameObject.Find("Info Player").GetComponent<TextMeshProUGUI>().text = $"{currentAllowedBombs}/{allowedBombs}";
        else
        {
            if (player1)
                GameObject.Find("Info Player1").GetComponent<TextMeshProUGUI>().text = $"{currentAllowedBombs}/{allowedBombs}";
            if (player2)
                GameObject.Find("Info Player2").GetComponent<TextMeshProUGUI>().text = $"{currentAllowedBombs}/{allowedBombs}";
        }
    }
    private void PlayerAnimation()
    {
        if (player1)
        {
            var animator = GetComponent<Animator>();
            animator.SetInteger("Direction", (int)direction);
        }
    } 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
            Instantiate(PlayerDeathEffect, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "PowerUp")
        {
            switch (other.gameObject.GetComponent<PowerUp>().powerUpNumber)
            {
                case (int)PowerUps.fireLength:                    
                    AddFireLength();
                    break;
                case (int)PowerUps.addSpeed:
                    AddSpeed();
                    break;
                case (int)PowerUps.addBombs:
                    AddBombs();
                    break;
            }
            Destroy(other.gameObject);
        }
    }

    public void AddFireLength()
    {
        fireLength++;
    }
    private void AddBombs()
    {
        allowedBombs++;
    }
    public int GetFireLength() => fireLength;

    public void StopPlayer()
    {
        isStoped = true;
    }
}
