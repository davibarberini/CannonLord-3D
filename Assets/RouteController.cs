using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    public WaveController waveScript;
    GameObject[] enemies;
    float enemyCount = 0;

    // Update is called once per frame
    void Update()
    {
        //Se o count for maior que o tempo entre os inimigos, spawna um inimigo e define os wavepoints dele
        if (enemyCount >= waveScript.enemyCooldown)
        {
            GameObject[] wp = GetAllChilds(gameObject);
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], transform.position, Quaternion.identity).GetComponent<enemyScript>().SetWavePoints(wp);
            enemyCount = 0;
        }

        enemyCount += Time.deltaTime;
    }

    //Define os inimigos que essa rota invocará
    public void SetEnemies(GameObject[] g)
    {
        enemies = g;
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
