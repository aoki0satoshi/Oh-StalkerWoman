﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour 
{
	void Start () 
    {
		
	}

    void Update () 
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("StalkerMode");
        }
	}
}
