using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class managerScript : MonoBehaviour
{
    public GameObject[] waves;
    public GameObject slidingText, mainCanvas;
    public TextMeshProUGUI scoreTXT, vidaTXT;
    public float waveCooldown;
    public int level;
    public int maxWaveCount;
    public bool started = false;
    public bool end = false;

    public static int score;
    public static int vida;
    static bool waveDone;

    int waveCount = 0;
    
    float waveSpawnCount = 0;
    static GameObject currentWave;
    GameObject currentSlidingText;

    private void Start()
    {
        waveDone = true;
        score = 100000000;
        vida = 100;
        currentWave = null;
        scoreTXT.text = "Money: $" + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            //Instancia a primeira wave quando o count for maior que o waveCooldown
            if (waveSpawnCount >= waveCooldown && waveDone)
            {
                CheckLevel();
                if (!currentSlidingText)
                {
                    int r = Random.Range(0, waves.Length);
                    currentWave = Instantiate(waves[r], transform.position, Quaternion.identity);
                    currentWave.GetComponent<WaveController>().SetLevel(level);
                    waveDone = false;
                    waveCount += 1;
                    waveSpawnCount = 0;
                    currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
                    currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Wave " + waveCount + "/" + maxWaveCount;
                }
            }

            if (vida <= 0)
            {
                vida = 0;
                end = true;
                started = false;
            }

            if (waveDone)
            {
                waveSpawnCount += Time.deltaTime;
            }

            //Define o texto do score no canvas
            scoreTXT.text = "Money: $" + score;
            vidaTXT.text = "Vida: " + vida;
        }
        
    }

    public void initialText()
    {
        currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
        currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Level " + level;
    }

    public static void addScore(int n)
    {
        score += n;
    }

    public static void checkWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && !currentWave.GetComponent<WaveController>().enemiesSpawning())
        {
            Destroy(currentWave);
            waveDone = true;
            Debug.Log("Entrou");
        }
    }

    void CheckLevel()
    {
        if(waveCount >= maxWaveCount)
        {
            level += 1;
            waveCount = 0;
            currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
            currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Level " + level;
        }
    }

}
