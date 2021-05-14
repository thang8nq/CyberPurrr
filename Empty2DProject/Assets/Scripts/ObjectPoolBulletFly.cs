using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBulletFly : MonoBehaviour
{

    public static ObjectPoolBulletFly SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public static int amountToPool = 10;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        GameObject tmp;
        tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
        amountToPool++;
        return tmp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
