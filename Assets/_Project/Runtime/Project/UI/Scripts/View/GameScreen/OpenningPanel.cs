using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class OpenningPanel : MonoBehaviour
{
    public Volume OpenVolume;
    private Vignette _vg;
    public bool FinalStatus;

    public void Start()
    {   
        OpenVolume.profile.TryGet(out _vg);
        FinalStatus=true;
    }

    void Update()
    {
        if (FinalStatus && _vg.intensity.value <= 1f)
        {
            _vg.intensity.value -= 0.00008f*Time.fixedTime;
        }
    }
}
