using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FinalPanel : MonoBehaviour
{
    public Volume FinalVolume;
    private Vignette _vg;
    public bool FinalStatus;
    public GameObject DieVolume;
    public GameObject FinalVolumee;
    public GameObject OpenVolume;
    public CanvasGroup ToBeContinued;
    public GameObject EndScreen;

    public void Start(){
        ToBeContinued.alpha = 0;
        EndScreen.active=false;
        FinalVolume.profile.TryGet(out _vg);
    }

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
            _vg.intensity.value += 0.00015f*Time.fixedTime;
        }
        if(_vg.intensity.value==1){
            EndScreen.active = true;
            DOTween.To(()=>ToBeContinued.alpha,x=>ToBeContinued.alpha=x,1,5);
        }
    }

    public void EndReturnMenu()
    {
        ToBeContinued.alpha = 0;
        if(ToBeContinued.alpha == 0){
            _vg.intensity.value = 0;
            EndScreen.active = false;
        }
        SceneManager.LoadScene(2);
    }
}
