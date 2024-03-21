using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Vignette = UnityEngine.Rendering.Universal.Vignette;

public class vignette : MonoSingleton<vignette>
{   
    private Volume v;
    public Vignette vg;
    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Volume>();
        
        v.profile.TryGet(out vg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
