using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerTrigger : MonoBehaviour
{
    public int SpeakerNumber;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Character"){
            SoundManager.Instance.Audio(SpeakerNumber);
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}
