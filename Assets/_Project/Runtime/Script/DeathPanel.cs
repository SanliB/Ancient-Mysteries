using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeathPanel : MonoSingleton<DeathPanel>
{
    private Vignette a;
    public bool b;

    public void returnGame()
    {
        SoundManager.Instance.Audio(4);
        b = true;
        gameObject.SetActive(true);
        a = vignette.Instance.vg;
        //a.intensity.value = 0;
        Time.timeScale = 0;
    }
    
    public void DieScene()
    {
        a.intensity.value = 0;
        gameObject.SetActive(false);
        Time.timeScale = 1;
        CharacterController _cc = CharacterController2.Instance._cc;
        _cc.enabled = false;
        _cc.transform.position=new Vector3(-19,-8.5f,18);
        _cc.enabled = true;
    }

    void Update()
    {
        if (b && a.intensity.value <= 0.7f)
        {
            a.intensity.value += 0.0003f*Time.fixedTime;
        }
    }
}
