using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private bool isFromLeft = true;
    private float m_Speed = 2.0f; 

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
    }
}
