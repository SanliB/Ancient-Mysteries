using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class EndScreenPanel : MonoBehaviour
{
    public CanvasGroup ToBeContinued;
    void Start()
    {
        ToBeContinued.alpha = 0;
    }

    void Update()
    {
        if(ToBeContinued.alpha==0){
            DOTween.To(()=>ToBeContinued.alpha,x=>ToBeContinued.alpha=x,1,1);
        }
    }

    public void EndReturnMenu(){
        ToBeContinued.alpha = 0;
        
        SceneManager.LoadScene(2);
    }
}
