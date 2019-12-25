using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float vida;
    public float velocity;
    Transform t;
    GameObject[] wavePoints;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se a vida do inimigo for abaixo de zero, ele é destruido
        if(vida <= 0)
        {
            Destroy(gameObject);
        }

        //Move o inimigo até o wavepoint
        t.position = Vector3.MoveTowards(t.position, wavePoints[count].transform.position, velocity);

        //Muda o wavePoint quando o inimigo chegar nele
        if(Vector3.Distance(t.position, wavePoints[count].transform.position) < 0.1f)
        {
            count += 1;
            if(count >= wavePoints.Length)
            {
                count = 0;
            }
        }
    }

    public void SetWavePoints(GameObject[] wp)
    {
        wavePoints = wp;
    }
}
