using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BrickDeathEffect;
    public GameObject ExtraFire;
    public GameObject SpeedUp;
    public GameObject AdditionalBombs;

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
            int number = Random.Range(0, 10);
            if (number % 4 == 0)
                Instantiate(AdditionalBombs, transform.position, transform.rotation);
            else if (number % 2 == 0)
                Instantiate(ExtraFire, transform.position, transform.rotation);
            else if (number % 2 == 1)
                Instantiate(SpeedUp, transform.position, transform.rotation);
            
        }
    }
}
