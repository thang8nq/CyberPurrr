using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private bool isFromLeft = true;
    private float m_Speed = 2.0f;
    private bool isSpawnSoilder = false; 
    public GameObject m_soilder; 
    
    // Start is called before the first frame update
    void Start()
    {
        isFromLeft = transform.position.x > 0 ? false : true;
    }

    // Update is called once per frame
    void Update()
    {
        //moving helicopter follow it's direction
        if (isFromLeft)
            transform.Translate(Vector3.right * Time.deltaTime * m_Speed);
        else
            transform.Translate(Vector3.left * Time.deltaTime * m_Speed);

        if(!isSpawnSoilder)
        {
            float randomTime = Random.Range(1, 3);
            Invoke("SpawnSoilder", randomTime);
            SpawnSoilder();
            isSpawnSoilder = true;
        }
    }

    public GameObject SpawnSoilder()
    {
        GameObject instance = null;

        Vector3 currentPos = this.transform.position;

        instance = Instantiate(m_soilder, currentPos, Quaternion.identity);

        if(!isFromLeft)
            instance.transform.localScale = new Vector3(-1, 1, 1);

        return instance;
    }
}
