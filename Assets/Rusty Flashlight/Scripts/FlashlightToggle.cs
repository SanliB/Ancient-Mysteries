﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = false; //is flashlight on or off?
    public Camera Cam;

    // Use this for initialization
    void Start()
    {
        //set default off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        

        Quaternion target = Quaternion.Euler(Cam.transform.rotation.eulerAngles.x+90, Cam.transform.rotation.eulerAngles.y, Cam.transform.rotation.eulerAngles.z);
        transform.rotation=Quaternion.Lerp(transform.rotation,target,0.3f);
        
        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.X))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            if (isOn)
            {
                
                lightGO.SetActive(true);
            }
            //turn light off
            else
            {
                lightGO.SetActive(false);

            }
        }
    }
}