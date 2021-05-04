using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public static float SCREEN_W = Screen.width;
    public static float SCREEN_H = Screen.height;
    private bool isSetUpDone = false;

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
