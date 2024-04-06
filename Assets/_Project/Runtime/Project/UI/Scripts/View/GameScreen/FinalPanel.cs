using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FinalPanel : MonoBehaviour
{
    public Volume FinalVolume;
    private Vignette _vg;
    public bool FinalStatus;
    public GameObject DieVolume;
    public GameObject FinalVolumee;
    public GameObject OpenVolume;

    public void FinalScreen()
    {   
        DieVolume.SetActive(false);
        OpenVolume.SetActive(false);
        FinalVolumee.SetActive(true);
        
        FinalVolume.profile.TryGet(out _vg);
        FinalStatus=true;
    }

    void Update()
    {
        if (FinalStatus && _vg.intensity.value <= 1f)
        {
            _vg.intensity.value += 0.00008f*Time.fixedTime;
        }
    }
}
