using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class managerScript : MonoBehaviour
{
    public GameObject[] waves;
    public TextMeshProUGUI scoreTXT;
    public float waveCooldown;
    public int level;

    public static int score;
    static bool waveDone;

    float waveCount = 0;
    static GameObject currentWave;

    private void Start()
    {
        waveDone = true;
        score = 10000;
        currentWave = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Instancia a primeira wave quando o count for maior que o waveCooldown
        if (waveCount >= waveCooldown && waveDone)
        {
            int r = Random.Range(0, waves.Length);
            currentWave = Instantiate(waves[r], transform.position, Quaternion.identity);
            currentWave.GetComponent<WaveController>().SetLevel(level);
            waveDone = false;
            waveCount = 0;
        }

        if (waveDone)
        {
            waveCount += Time.deltaTime;
        }

        //Define o texto do score no canvas
        scoreTXT.text = "Money: $" + score;
    }

    public static void addScore(int n)
    {
        score += n;
    }

    public static void checkWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
        {
            Destroy(currentWave);
            waveDone = true;
            Debug.Log("Entrou");
        }
    }

}
