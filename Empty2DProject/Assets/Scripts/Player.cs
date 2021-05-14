using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float timeInterval = 0.25f;
    public static float timeSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Define.playerPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawn += Time.deltaTime;

        //detect click 
        if (Input.GetMouseButtonDown(0))
        {
            if (timeSpawn > timeInterval)
            {
                SpawnBulletFly();
                timeSpawn = 0;
            }
        }
    }

    public GameObject SpawnBulletFly()
    {
        GameObject instance = ObjectPoolBulletFly.SharedInstance.GetPooledObject();

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Define.bulletBasePosition;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationZ = rotationZ - 90; //just test then subtract 90 to sync correctly on UI

        instance.transform.position = Define.bulletBasePosition;
        instance.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        instance.SetActive(true);
        return instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
