using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeathPanel : MonoSingleton<DeathPanel>
{
    
    private Vignette a;
    public bool b;
    void Start()
    {
         
    }
    
    public void returnGame()
    {
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
        CharacterController.Instance._rb.transform.position= new Vector3(-18,-10,18);
    }
    // Update is called once per frame
    void Update()
    {
        if (b && a.intensity.value <= 0.7f)
        {
            
            a.intensity.value += 0.0003f*Time.fixedTime;
        }
    }
}
