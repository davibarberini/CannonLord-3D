using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    public WaveController waveScript;
    public int loops;

    Transform t;
    GameObject[] enemies;
    GameObject[] wp;

    float spawnCount = 0;
    int enemiesCount = 0;
    int enemiesNumber = 5;
    bool canSpawn = true;

    private void Start()
    {
        t = GetComponent<Transform>();
        wp = GetAllChilds(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Se o count for maior que o tempo entre os inimigos, spawna um inimigo e define os wavepoints dele
        if (spawnCount >= waveScript.enemyCooldown && canSpawn)
        {
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], t.position, Quaternion.identity).GetComponent<enemyScript>().SetWavePoints(wp, loops);

            enemiesCount += 1;
            spawnCount = 0;

            //Se chegou no limite de inimigos spawnados, para de spawnar
            if(enemiesCount >= enemiesNumber)
            {
                canSpawn = false;
            }
        }

        spawnCount += Time.deltaTime;
    }

    //Define os inimigos que essa rota invocará
    public void SetEnemies(GameObject[] g, int howMuch)
    {
        enemies = g;
        enemiesNumber = howMuch;
    }

    //Funcão para pegar todos os objetos filhos de um outro objeto
    GameObject[] GetAllChilds(GameObject g)
    {
        GameObject[] childs = new GameObject[g.transform.childCount];
        for (int i = 0; i < g.transform.childCount; i++)
        {
            childs[i] = g.transform.GetChild(i).gameObject;
        }
        return childs;
    }

    //Funcao para saber se a rota está spawnando inimigos ou não
    public bool GetCanSpawn()
    {
        return canSpawn;
    }

}
