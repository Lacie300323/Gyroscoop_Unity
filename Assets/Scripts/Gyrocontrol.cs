﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyrocontrol : MonoBehaviour {


    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rotation;

	// Use this for initialization
	void Start () {

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();

	}
	
	// Update is called once per frame
	void Update ()
    { 
        if(gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotation;
        }

	}

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }
}
