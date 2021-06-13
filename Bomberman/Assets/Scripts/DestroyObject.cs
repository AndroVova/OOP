using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float delay;
    private float counter;
    void Start()
    {
        counter = delay;
    }

    void Update()
    {
        if (counter > 0)
            counter -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
