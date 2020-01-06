using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Ball;
    private float timeBtwSpawn;
    public  float startTimeBtwSpawn;
    public float decreaseTime;
    public int xSpawnVariance;
    public int ySpawnVariance;
    public Vector3 rndPos;
    public float minTime = .65f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwSpawn <= 0)
        {
            float rndx = Random.Range(0, xSpawnVariance);
            float rndy = Random.Range(0, ySpawnVariance);
            rndPos = new Vector3(rndx, rndy);
            Instantiate(Ball, transform.position + rndPos, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
