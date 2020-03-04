using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSushi : MonoBehaviour
{
    public GameObject sushi;
    public GameObject baiacu;
    public Transform[] spawnPoints;
    public float minDelay = 1.0f;
    public float maxDelay = 4.0f;
    private int spawnQtt;
    private int maxQtt = 3;
    private float gameTime;

    void Start()
    {
        StartCoroutine(spawnSushi());
    }
    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= 60)
        {
            maxQtt = 4;
        }
        if(gameTime >= 90)
        {
            maxDelay = 3.0f;
        }
    }


    IEnumerator spawnSushi()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            int spawnQtt = Random.Range(1, maxQtt);

            for(int i=0; i<spawnQtt; i++)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];
                int a = Random.Range(1, 10);
                if (a >= 6 && spawnQtt == 1 && maxQtt == 3 || a >= 2 && spawnQtt == 1 && maxQtt == 4)
                {
                    Instantiate(baiacu, spawnPoint.position, spawnPoint.rotation);
                }
                else
                {
                    Instantiate(sushi, spawnPoint.position, spawnPoint.rotation);
                }
            }

           
        }
    }
}




