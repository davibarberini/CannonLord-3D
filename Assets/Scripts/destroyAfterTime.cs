using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;

    float count = 0;

    // Update is called once per frame
    void Update()
    {
        //Destroy o objeto após o tempo indicado
        count += Time.deltaTime;
        if(count >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
