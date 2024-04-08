using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Vignette = UnityEngine.Rendering.Universal.Vignette;

public class vignette : MonoSingleton<vignette>
{   
    private Volume v;
    public Vignette vg;
    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out vg);
    }
}
