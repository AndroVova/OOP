using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BrickDeathEffect;
    public GameObject ExtraFire;
    public GameObject SpeedUp;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Brick")
        {
            Destroy(other.gameObject);
            Instantiate(BrickDeathEffect, transform.position, transform.rotation);
            PowerUpPlant();
        }
    }
    public void PowerUpPlant()
    {
        if (Random.Range(0, 100) % 3 == 0)
        {
            if (Random.Range(0, 10) % 2 == 0)
                Instantiate(ExtraFire, transform.position, transform.rotation);
            else
                Instantiate(SpeedUp, transform.position, transform.rotation);
        }
    }
}
