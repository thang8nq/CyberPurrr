using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soilder : MonoBehaviour
{
    private float m_speed = 1.5f;
    private bool isOnGround = false;
    public Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > Define.GROUND_POS_Y)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * m_speed);
        }
        else
        {
            isOnGround = true;
            anim.SetBool("isOnGround", isOnGround);
        }
    }
}
