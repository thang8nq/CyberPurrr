using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public static float SCREEN_W = Screen.width;
    public static float SCREEN_H = Screen.height;
    private bool isSetUpDone = false;

    public static float GROUND_POS_Y = -4.0f;

    public static Vector3 playerPosition;
    public static float BULLET_ANGLE_ROTATE_MAX = 90.0f;
    public static float BULLET_ANGLE_ROTATE_MIN = -90.0f;

    public static Vector3 bulletBasePosition;

    public static float BULLET_FORCE = 50.0f;
    public static bool isGameOver = false;
    public static bool isGameBegin = false;

    public static int score = 0; 

    public void Update()
    {
        if(!isSetUpDone)
        {
            if (SCREEN_W != Screen.width)
                SCREEN_W = Screen.width;

            if (SCREEN_H != Screen.height)
                SCREEN_H = Screen.height;

            isSetUpDone = true; 
        }
    }
}
