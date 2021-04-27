using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject helicopter;

    public static float timeInterval = 1.0f;
    public static float timeSpawn = 0f;
    public static bool isFromLeft = true; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawn += Time.deltaTime;

        if (timeSpawn > timeInterval)
        {
            SpawnHelicopter();
            timeSpawn = 0;
        }
    }

    public GameObject SpawnHelicopter()
    {
        GameObject instance = null;

        float randY = Random.Range(0.75f * Define.SCREEN_H, 0.95f * Define.SCREEN_H); //the range (height) helicopter spawn

        //left side
        Vector3 randPosL = Camera.main.ScreenToWorldPoint(new Vector3(0, randY));

        //right side 
        Vector3 randPosR = Camera.main.ScreenToWorldPoint(new Vector3(Define.SCREEN_W, randY));
        int randValue = Random.Range(-1, 2);
        if (randValue > 0)
            isFromLeft = true;
        else
            isFromLeft = false;

        if (isFromLeft)
        {
            Instantiate(helicopter, randPosL, Quaternion.identity);
        }
        else
        {
            instance = Instantiate(helicopter, randPosR, Quaternion.identity);
            instance.transform.localScale = new Vector3(-1, 1, 1); //this help helicopter show correct directions
        }

        return instance;
    }
}
