using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Define.bulletBasePosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RotateBullet();
    }

    void RotateBullet()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationZ = rotationZ - 90; //just test then subtract 90 to sync correctly on UI

        if (rotationZ >= Define.BULLET_ANGLE_ROTATE_MAX)
            rotationZ = Define.BULLET_ANGLE_ROTATE_MAX;

        if (rotationZ <= Define.BULLET_ANGLE_ROTATE_MIN)
            rotationZ = Define.BULLET_ANGLE_ROTATE_MIN;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    } 
}
