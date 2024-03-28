using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO;
    private bool isOn = false;
    public Camera Cam;

    void Start()
    {
        lightGO.SetActive(isOn);
    }

    void Update()
    {
        Quaternion target = Quaternion.Euler(Cam.transform.rotation.eulerAngles.x+90, Cam.transform.rotation.eulerAngles.y, Cam.transform.rotation.eulerAngles.z);
        transform.rotation=Quaternion.Lerp(transform.rotation,target,1f);
    }

    public void OnMouseDown()
    {
        SoundManager.Instance.Audio(7);
        if (isOn == false)
        {
            lightGO.SetActive(true);
            isOn = true;
        }
        else
        {
            isOn = false;
            lightGO.SetActive(false);
        }
    }
}
