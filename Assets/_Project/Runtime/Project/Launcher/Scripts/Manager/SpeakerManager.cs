using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeakerManager : MonoBehaviour
{
    public GameObject[] Speakers;
    
    public void SpeakerControl(int a){
        SoundManager.Instance.Audio(a);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.tag);
        
        if(other.tag=="Character"){
            SoundManager.Instance.Audio(16);
        }
    }
}
