using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject[] routes;
    public GameObject[] enemies;
    public float enemyCooldown;
    public int enemiesNumber;

    GameObject[] routeEnemies;

    int level = 0;


    public void SetLevel(int l)
    {
        //Define a dificuldade da fase de acordo com o level
        level = l;
        if(level < enemies.Length)
        {
            routeEnemies = new GameObject[level];
        }
        else
        {
            routeEnemies = new GameObject[enemies.Length];
        }
        for (int e = 0; e < routeEnemies.Length; e++)
        {
            routeEnemies[e] = enemies[e];
        }
        SetRouteEnemies();
    }

    void SetRouteEnemies()
    {
        //Define os inimigos que as routas invocarão
        for(int e=0; e < routes.Length; e++)
        {
            routes[e].GetComponent<RouteController>().SetEnemies(routeEnemies, enemiesNumber);
        }
    }

    
}
