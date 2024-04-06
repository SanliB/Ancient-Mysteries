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

    public void FinalScreen()
    {   
        FinalVolume.profile.TryGet(out _vg);
        FinalStatus=true;
    }

    void Update()
    {
        if (FinalStatus && _vg.intensity.value <= 1f)
        {
            _vg.intensity.value += 0.01f*Time.fixedTime;
        }
    }
}
