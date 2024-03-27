using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool light;
    public Camera Cam;

    public void Update()
    {
        transform.rotation=Quaternion.Lerp(transform.rotation,Cam.transform.rotation,0.3f);
        if (Input.GetKeyUp(KeyCode.E))
        {
            light = !light;
            flashlight.SetActive(light);
        }
    }
}