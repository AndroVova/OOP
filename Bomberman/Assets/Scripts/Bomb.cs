using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float delay;
    private float counter;

    public int fireLength;

    public LayerMask WallLayer;
    public LayerMask BrickLayer;

    public GameObject FireCenter;
    public GameObject FireHorizontal;
    public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject FireVertical;
    public GameObject FireUp;
    public GameObject FireDown;

    public Player Creator;
    public List<Vector2> CellsToBlowR;
    public List<Vector2> CellsToBlowL;
    public List<Vector2> CellsToBlowU;
    public List<Vector2> CellsToBlowD;

    void Start()
    {
        fireLength = Creator.fireLength;
        counter = delay;
        CellsToBlowR = new List<Vector2>();
        CellsToBlowL = new List<Vector2>();
        CellsToBlowU = new List<Vector2>();
        CellsToBlowD = new List<Vector2>();

    }

    void Update()
    {
        if (counter > 0)
            counter -= Time.deltaTime;
        else
        {
            Bang();
            Destroy(gameObject);
        }
    }

    void Bang()
    {
        CalculateFireDirections();
        Instantiate(FireCenter, transform.position, transform.rotation);

        DrawFire(FireLeft, FireHorizontal, CellsToBlowL);
        DrawFire(FireRight, FireHorizontal, CellsToBlowR);
        DrawFire(FireUp, FireVertical, CellsToBlowU);
        DrawFire(FireDown, FireVertical, CellsToBlowD);
    }
    void CalculateFireDirections()
    {
        CountCellToBlow(-1, 0, CellsToBlowL);
        CountCellToBlow(1, 0, CellsToBlowR);
        CountCellToBlow(0, 1, CellsToBlowU);
        CountCellToBlow(0, -1, CellsToBlowD);
    }

    private void CountCellToBlow(int dx, int dy, List<Vector2> CellsToBlow)
    {
        for (int i = 1; i <= fireLength; i++)
        {
            if (IsBarrierNear(dx, dy, i, WallLayer))
                break;

            if (IsBarrierNear(dx, dy, i, BrickLayer))
            {
                CellsToBlow.Add(new Vector2(transform.position.x + dx * i,
                                            transform.position.y + dy * i));
                break;
            }
            CellsToBlow.Add(new Vector2(transform.position.x + dx * i,
                                        transform.position.y + dy * i));
        }
    }

    private bool IsBarrierNear(int dx, int dy, int index, LayerMask barrier) 
        => Physics2D.OverlapCircle(new Vector2(transform.position.x + dx * index,
                                               transform.position.y + dy * index), 0.1f, barrier);

    private void DrawFire(GameObject FireLast, GameObject FireMiddle, List<Vector2> CellsToBlow)
    {
            for (int i = 0; i < CellsToBlow.Count; i++)
            {
                if (i == CellsToBlow.Count - 1)
                    Instantiate(FireLast, CellsToBlow[i], transform.rotation);
                else
                    Instantiate(FireMiddle, CellsToBlow[i], transform.rotation);
            }
    }

}
