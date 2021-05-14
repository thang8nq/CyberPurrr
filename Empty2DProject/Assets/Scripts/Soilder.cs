using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soilder : MonoBehaviour
{
    private float m_speed = 1.5f;
    private bool isOnGround = false;
    public Animator anim;
    private Rigidbody2D rb;
    private bool m_beHit = false; 

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
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

            float soilderPosX = this.transform.position.x;
            if (soilderPosX < Define.playerPosition.x)
                this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
            else
                this.transform.Translate(Vector3.left * m_speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

        }
        else if(col.CompareTag("Bullet"))
        {
            Vector2 vecForce = col.gameObject.transform.position;
            rb.AddForce(vecForce * Define.BULLET_FORCE);
            rb.gravityScale = 1;
            m_beHit = true;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.RandomRange(30, 60));
        }
        else if(col.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
