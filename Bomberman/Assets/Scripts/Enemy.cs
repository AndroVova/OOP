using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<Location> path = new List<Location>();
    public GameObject Player;
    public GameObject EnemyDeathEffect;
    public GameObject PlayerDeathEffect;

    public float moveSpeed;
    public LayerMask BarrierLayer;

    private bool canMove = false;
    private bool reverseMovement = true;
    private PathFinding pathFinding;

    void Start()
    {
        pathFinding = GetComponent<PathFinding>();
    }


    void FixedUpdate()
    {
        if (FindObjectOfType<Visuals>().gameIsActive && Player != null)
        {
            Move();
            EnemyAnimation();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
            Instantiate(EnemyDeathEffect, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "PowerUp")
        {            
            if (other.gameObject.GetComponent<PowerUp>().powerUpNumber == 1)
                AddSpeed();                            
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Instantiate(PlayerDeathEffect, other.transform.position, other.transform.rotation);
        }
    }

    private void AddSpeed()
    {
        moveSpeed++;
    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) > 0)
            path = pathFinding.CalculateIdealPath();

        if (path.Count == 1) 
            return;

        else if (seePlayer())
            EnemyIntelectualMove();
        else
            NormalEnemyMove();        
        
        if (!canMove)
        {
            reverseMovement = !reverseMovement;
            canMove = true;
        }
    }
    private void NormalEnemyMove()
    {
        if (isBarrierNear)
        {
            if (canMove && reverseMovement)
                EnemyMove(1, 0);
            else if (canMove && !reverseMovement)
                EnemyMove(-1, 0);
        }
        else
        {
            if (canMove && !reverseMovement)
                EnemyMove(0, 1);
            else if (canMove && reverseMovement)
                EnemyMove(0, -1);
        }

        canMove = !Physics2D.OverlapBox(transform.position, new Vector2(0.9f, 0.9f), 0, BarrierLayer);        
    }

    

    private void EnemyIntelectualMove()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 new Vector2(path[1].X, 
                                                             path[1].Y),
                                                 moveSpeed * Time.deltaTime);
    }

    private void EnemyMove(int dx, int dy)
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 new Vector2(Mathf.Round(transform.position.x + dx), 
                                                             Mathf.Round(transform.position.y + dy)),
                                                 moveSpeed * Time.deltaTime);
    }

    
    public bool seePlayer()
    {
        if (Player != null)
            return path.Count < 10 && 
                   isPlayer(path[path.Count - 1].X, 
                            path[path.Count - 1].Y);
        else
            return false;
    }
    private bool isPlayer(int dx, int dy)
         => new Vector2(dx, dy) == new Vector2(Mathf.Round(Player.transform.position.x),
                                               Mathf.Round(Player.transform.position.y));
    private bool isBarrierNear
         => Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), new Vector2(0.9f, 0.9f), 0, BarrierLayer) &&
            Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 1), new Vector2(0.9f, 0.9f), 0, BarrierLayer);

    private void EnemyAnimation()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("See Player", seePlayer());
    }
}

