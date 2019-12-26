using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float vida;
    public int scoreAmount;
    public float velocity;
    public ParticleSystem deathParticle;

    Renderer rend;
    ParticleSystemRenderer particleRend;
    Transform t;
    GameObject[] wavePoints;

    int count = 0;
    int voltas = 0;
    int maxVoltas = 2;
    float countToDestroy = 0;
    bool stopLoop = false;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        particleRend = deathParticle.GetComponent<ParticleSystemRenderer>();
        CheckColor();
    }

    // Update is called once per frame
    void Update()
    {
        //Se a vida do inimigo for abaixo de zero, ele é destruido
        if(vida <= 0)
        {
            managerScript.addScore(scoreAmount);
            managerScript.checkWave();
            /*ParticleSystem particle = Instantiate(deathParticle, t.position, Quaternion.identity);
            Destroy(particle.gameObject, 3f);*/
            Destroy(gameObject);
        }

        //Move o inimigo até o wavepoint
        if (!stopLoop)
        {
            t.position = Vector3.MoveTowards(t.position, wavePoints[count].transform.position, velocity);
        }
        else
        {
            t.position += t.forward * velocity * 100 * Time.deltaTime;
            countToDestroy += Time.deltaTime;
            if(countToDestroy >= 2f)
            {
                managerScript.checkWave();
                Destroy(gameObject);
            }
        }
        

        //Muda o wavePoint quando o inimigo chegar nele
        if(Vector3.Distance(t.position, wavePoints[count].transform.position) < 0.1f)
        {
            count += 1;
            if(count >= wavePoints.Length)
            {
                count = 0;
                voltas += 1;

                if(voltas > maxVoltas && !stopLoop)
                {
                    stopLoop = true;
                }
            }
        }
    }

    //Define o caminho que o inimigo irá percorrer
    public void SetWavePoints(GameObject[] wp, int v)
    {
        wavePoints = wp;
        maxVoltas = v;
    }


    //Faz o inimigo receber dano
    public void TakeDamage(float amount)
    {
        ParticleSystem particle = Instantiate(deathParticle, t.position, Quaternion.identity);
        CheckParticleColors(particle);
        Destroy(particle.gameObject, 3f);
        vida -= amount;
    }


    //Muda a cor do inimigo de acordo com a sua vida atual
    public void CheckColor()
    {
        if(vida <= 10)
        {
            rend.material.SetColor("_Color", Color.red);
        }
        else if(vida <= 20)
        {
            rend.material.SetColor("_Color", Color.green);
        }
        else if (vida <= 30)
        {
            rend.material.SetColor("_Color", Color.yellow);
        }

    }

    public void CheckParticleColors(ParticleSystem particle)
    {
        particleRend = particle.GetComponent<ParticleSystemRenderer>();
        if (vida <= 10)
        {
            particleRend.material.SetColor("_Color", Color.red);
        }
        else if (vida <= 20)
        {
            particleRend.material.SetColor("_Color", Color.green);
        }
        else if (vida <= 30)
        {
            
            particleRend.material.SetColor("_Color", Color.yellow);
        }
    }

}
