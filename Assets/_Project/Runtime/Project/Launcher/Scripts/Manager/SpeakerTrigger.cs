using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerTrigger : MonoBehaviour
{
    public int SpeakerNumberEN;
    public int SpeakerNumberTR;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Character")
        {
            if (PlayerPrefs.GetString("Language") == "EN")
            {
                SoundManager.Instance.Audio(SpeakerNumberEN,0.8f);
            }
            else
            {
                SoundManager.Instance.Audio(SpeakerNumberTR, 0.8f);
            }
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
