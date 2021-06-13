using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private bool buttonRight;
    private bool buttonLeft;
    private bool buttonUp;
    private bool buttonDown;
    private bool buttonBomb;

    public bool player1;
    public bool player2;

    private bool canMove = false;
    public bool isStoped = false;

    public Transform sensor;

    public GameObject Bomb;
    public GameObject PlayerDeathEffect;

    public float sensorSize;
    public float sensorRange;

    public int moveSpeed;
    private int direction;
    public int fireLength;

    public LayerMask WallLayer;

    enum Directions
    {
        up = 8,
        left = 4,
        right = 6,
        down = 2
    }

    void Start()
    {
        //fireLength = 2;
    }

    void Update()
    {
        if (!isStoped) {
            GetInput();
            GetDirection();
            MoveSensor();
            PlantBomb();
            Move();

            PlayerAnimation();
        }
    }
    private void GetInput()
    {
        buttonRight = (Input.GetKey(KeyCode.RightArrow) && player2 ||
                       Input.GetKey(KeyCode.D)          && player1);

        buttonLeft =  (Input.GetKey(KeyCode.LeftArrow) && player2 ||
                       Input.GetKey(KeyCode.A)         && player1);
         
        buttonDown =  (Input.GetKey(KeyCode.DownArrow) && player2 ||
                       Input.GetKey(KeyCode.S)         && player1);

        buttonUp =  (Input.GetKey(KeyCode.UpArrow) && player2 ||
                     Input.GetKey(KeyCode.W)       && player1);
        ///podumat`
        buttonBomb = Input.GetKeyDown(KeyCode.E)           && player1 || 
                     Input.GetKeyDown(KeyCode.KeypadEnter) && player2;
    }

    private void GetDirection()
    {
        direction = 0;
        if (buttonUp) direction = (int)Directions.up;
        if (buttonRight) direction = (int)Directions.right;
        if (buttonLeft) direction = (int)Directions.left;
        if (buttonDown) direction = (int)Directions.down;
        
    }

    private void MoveSensor()
    {
        sensor.transform.localPosition = new Vector2(0, 0);
        switch (direction)
        {
            case (int)Directions.up:
                sensor.transform.localPosition = new Vector2(0, sensorRange);
                break;
            case (int)Directions.right:
                sensor.transform.localPosition = new Vector2(sensorRange, 0);
                break;
            case (int)Directions.left:
                sensor.transform.localPosition = new Vector2(-sensorRange, 0);
                break;
            case (int)Directions.down:
                sensor.transform.localPosition = new Vector2(0, -sensorRange);
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
            case (int)Directions.down:
                transform.position = VerticalMove(-1);
                break;            
            case (int)Directions.left:
                transform.position = HorizontalMove(-1);
                break;
            case (int)Directions.right:
                transform.position = HorizontalMove(1);
                break;
            case (int)Directions.up:
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
        if (buttonBomb)
        {  
            Instantiate(Bomb, new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), transform.rotation);
            FindObjectOfType<Bomb>().Creator = this;
        }
    }

    private void PlayerAnimation()
    {
        if (player1)
        {
            var animator = GetComponent<Animator>();
            animator.SetInteger("Direction", direction);
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
                case 0:                    
                    AddFireLength();
                    print(fireLength);
                    break;
                case 1:
                    AddSpeed();
                    break;
            }

            Destroy(other.gameObject);
        }
    }

    public void AddFireLength()
    {
        fireLength++;
    }

    public int GetFireLength() =>fireLength;

    public void StopPlayer()
    {
        isStoped = true; ///
    }
}
