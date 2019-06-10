using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps : MonoBehaviour 
{
    void Awake()
    {
        //60FPSに設定
        Application.targetFrameRate = 60; 
    }
}
