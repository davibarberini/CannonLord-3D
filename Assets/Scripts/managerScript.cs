using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class managerScript : MonoBehaviour
{
    public GameObject[] waves;
    public GameObject slidingText, mainCanvas;
    public AudioSource audioSource;
    public AudioClip textSound, waveEndSound, nextLevelSound, loseSound;
    public TextMeshProUGUI scoreTXT, vidaTXT;
    public PlayerController plyScript;
    public UpgradeScript damageUp, velocityUp, fireRateUp, automaticUp;
    public float waveCooldown;
    public int level;
    public int timeToSave;
    public int maxWaveCount;
    public bool started = false;
    public bool end = false;
    public info inf;

    public static int score;
    public static int vida;
    static bool waveDone;
    static bool waveDoneSound = false;

    int waveCount = 0;
    
    float waveSpawnCount = 0;
    float saveCount = 0;
    static GameObject currentWave;
    GameObject currentSlidingText;

    private void Start()
    {
        inf.loadSave();
        SetData();
        waveDone = true;
        vida = 100;
        currentWave = null;
        scoreTXT.text = "Money: $" + score;

        if(level == 0)
        {
            level = 1;
        }

        Time.timeScale = 1f;
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
                    audioSource.PlayOneShot(textSound, 0.2f);
                    currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
                    currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Wave " + waveCount + "/" + maxWaveCount;
                }
            }
            
            //Se a vida for menor do que 0 ele muda a variavel end para verdadeiro para depois reiniciar a fase
            if (vida <= 0)
            {
                audioSource.PlayOneShot(loseSound, 0.3f);
                vida = 0;
                end = true;
                started = false;
            }

            //Se as waves acabaram ele roda o contador pra instanciar a proxima
            if (waveDone)
            {
                waveSpawnCount += Time.deltaTime;
                if (!waveDoneSound)
                {
                    audioSource.PlayOneShot(waveEndSound, 0.3f);
                    waveDoneSound = true;
                }
            }

        }

        //Define o texto do score no canvas
        scoreTXT.text = "Money: $" + score;
        vidaTXT.text = "Life: " + vida;

        //Salva o jogo após determinado tempo
        saveCount += Time.deltaTime;
        if(saveCount >= timeToSave)
        {
            SaveData();
            saveCount = 0;
        }

        //Reseta o save completamente, para testes apenas
        if (Input.GetKeyDown(KeyCode.R))
        {
            inf.resetSave();
            inf.saveGame();
            SetData();
        }

        //Adiciona 1000 de dinheiro, para testes apenas
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            score += 1000;
        }

    }

    //Chama a funcao para definir os atributos da info e depois salva os dados no arquivo
    public void SaveData()
    {
        SetInfoData();
        inf.saveGame();
    }

    //Instancia o texto inicial mostrando o level atual
    public void initialText()
    {
        audioSource.PlayOneShot(textSound, 0.2f);
        currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
        currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Level " + level;
    }

    //Adiciona um valor ao score
    public static void addScore(int n)
    {
        score += n;
    }

    //Confere se a wave acabou
    public static void checkWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && !currentWave.GetComponent<WaveController>().enemiesSpawning())
        {
            Destroy(currentWave);
            waveDone = true;
            waveDoneSound = false;
            Debug.Log("Entrou");
        }
    }

    //Confere se passou o numero de waves necessárias para passar de level
    void CheckLevel()
    {
        if(waveCount >= maxWaveCount)
        {
            audioSource.PlayOneShot(nextLevelSound, 0.3f);
            level += 1;
            waveCount = 0;
            audioSource.PlayOneShot(textSound, 0.2f);
            currentSlidingText = Instantiate(slidingText, mainCanvas.transform);
            currentSlidingText.GetComponent<TextMeshProUGUI>().text = "Level " + level;
        }
    }

    //Define todos os dados necessários a partir do que foi carregado no info
    void SetData()
    {
        score = inf.money;
        level = inf.level;

        plyScript.damage = 10 + (inf.damageUpgrade * damageUp.upgradeAmount);
        plyScript.bulletVelocity = 200 + (inf.velocityUpgrade * velocityUp.upgradeAmount);
        plyScript.fireRate = 2 + (inf.fireRateUpgrade * fireRateUp.upgradeAmount);
        plyScript.automatic = inf.automaticUpgrade;

        damageUp.SetPrice(damageUp.firstPrice * ( (int) Mathf.Pow(2, inf.damageUpgrade - 1)), inf.damageUpgrade);
       
        velocityUp.SetPrice(velocityUp.firstPrice * ((int)Mathf.Pow(2, inf.velocityUpgrade - 1)), inf.velocityUpgrade);

        fireRateUp.SetPrice(fireRateUp.firstPrice * ((int)Mathf.Pow(2, inf.fireRateUpgrade - 1)), inf.fireRateUpgrade);

        if (inf.automaticUpgrade)
        {
            automaticUp.SetPrice(automaticUp.firstPrice, 1);
        }
        else
        {
            automaticUp.SetPrice(automaticUp.firstPrice, 0);
        }
        
    }

    //Define os dados no info antes de dar o save para o arquivo
    public void SetInfoData()
    {
        inf.damageUpgrade = damageUp.upgradeValue;
        inf.velocityUpgrade = velocityUp.upgradeValue;
        inf.fireRateUpgrade = fireRateUp.upgradeValue;
        inf.automaticUpgrade = plyScript.automatic;
        inf.level = level;
        inf.money = score;
    }

}
