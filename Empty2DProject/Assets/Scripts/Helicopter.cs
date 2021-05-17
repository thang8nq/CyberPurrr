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
            isSpawnSoilder = true;
            float randomTime = Random.Range(3, 6);
            Invoke("SpawnSoilder", randomTime);
            SpawnSoilder();
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

    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        isSpawnSoilder = false;
    }

    public void OnBecameVisible()
    {
        isFromLeft = transform.position.x > 0 ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);
            HitHelicopter();
        }
    }

    public void HitHelicopter()
    {
        Define.score += 1; 
    }
}
