using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerScript : MonoBehaviour
{
    public GameObject[] waves;
    public float waveCooldown;
    public int level;
    float waveCount = 0;
    bool waveDone = true;

    // Update is called once per frame
    void Update()
    {
        waveCount += Time.deltaTime;
        if(waveCount >= waveCooldown && waveDone)
        {
            int r = Random.Range(0, waves.Length);
            Instantiate(waves[r], transform.position, Quaternion.identity).GetComponent<WaveController>().SetLevel(level);
            waveDone = false;
            waveCount = 0;
        }
    }
}
