using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using deneme;

public class Chest : MonoBehaviour
{
    
    public int SpeakerNumberEN, SpeakerNumberTR, Counter;
    public bool ChestStatus, a = false;
    public Sprite KeySprite;

    public void Start()
    {
        Counter = 7;
    }

    private void Update()   
    {
        if (ChestStatus)
        {
            deneme.canvasManagerforGameEpisodes.Instance.DeleteItemForEnv(KeySprite);
            gameObject.GetComponent<Animation>().Play();
            ChestStatus = false;
            a= true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    

    private void OnMouseDown()
    {
        if(!a && Key.Instance.status)
        {
            SoundManager.Instance.Audio(13,PlayerPrefs.GetFloat("audioVolume"));
            ChestStatus = true;
        }
        else
        {
            
            SoundManager.Instance.Audio(9,PlayerPrefs.GetFloat("audioVolume"));
            if (Counter ==7)
            {
                StartCoroutine(Wait(1));
                Counter = 0;
            }
            Counter++;
        }
    }
    
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (PlayerPrefs.GetString("Language") == "EN")
            SoundManager.Instance.Audio(SpeakerNumberEN,0.8f);
        else
            SoundManager.Instance.Audio(SpeakerNumberTR, 0.8f);
    }

}


