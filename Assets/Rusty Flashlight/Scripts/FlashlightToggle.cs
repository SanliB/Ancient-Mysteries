using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO;
    private bool isOn = false, Counter;
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
        SoundManager.Instance.Audio(7,PlayerPrefs.GetFloat("audioVolume"));
        if(Counter==false){
            StartCoroutine(WaitSpeaker());
            Counter=true;
        }
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

    private IEnumerator WaitSpeaker()
    {
        yield return new WaitForSeconds(0.5f);
        if (PlayerPrefs.GetString("Language") == "TR")
            SoundManager.Instance.Audio(31, 0.8f);
        else
            SoundManager.Instance.Audio(18, 0.8f);
    }
}
