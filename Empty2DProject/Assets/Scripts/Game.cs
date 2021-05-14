using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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

        //detect click 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if(hitCollider != null && hitCollider.transform.tag == "Helicopter")
                hitCollider.gameObject.SetActive(false);
        }
    }

    public GameObject SpawnHelicopter()
    {
        //Get a helicopter
        GameObject instance = ObjectPool.SharedInstance.GetPooledObject();
        instance.transform.rotation = Quaternion.identity;

        //Setup position & flip 
        float randY = Random.Range(0.75f * Define.SCREEN_H, 0.95f * Define.SCREEN_H); //the range (height) helicopter spawn

        //left side
        Vector3 randPosL = Camera.main.ScreenToWorldPoint(new Vector3(0, randY, 1));

        //right side 
        Vector3 randPosR = Camera.main.ScreenToWorldPoint(new Vector3(Define.SCREEN_W, randY, 1));
        int randValue = Random.Range(-1, 2);

        //random value to decide where spawn helicopter (position: left/right)
        if (randValue > 0)
            instance.transform.position = randPosL;
        else 
            instance.transform.position = randPosR;

        //check spawn position (only care on x's value) to flip helicopter to correct direction
        if (instance.transform.position.x > 0)
            instance.transform.localScale = new Vector3(-1, 1, 1);
        else
            instance.transform.localScale = new Vector3(1, 1, 1);

        instance.SetActive(true);

        return instance;
    }
}