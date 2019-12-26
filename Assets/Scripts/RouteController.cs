using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    public WaveController waveScript;
    public int loops;

    GameObject[] enemies;

    float spawnCount = 0;
    int enemiesCount = 0;
    int enemiesNumber = 5;
    bool canSpawn = true;


    // Update is called once per frame
    void Update()
    {
        //Se o count for maior que o tempo entre os inimigos, spawna um inimigo e define os wavepoints dele
        if (spawnCount >= waveScript.enemyCooldown && canSpawn)
        {
            GameObject[] wp = GetAllChilds(gameObject);
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], transform.position, Quaternion.identity).GetComponent<enemyScript>().SetWavePoints(wp, loops);

            enemiesCount += 1;
            spawnCount = 0;

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

}
