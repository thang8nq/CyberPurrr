using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private float m_speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * m_speed);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
