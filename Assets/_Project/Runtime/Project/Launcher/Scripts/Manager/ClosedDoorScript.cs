using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClosedDoorScript : MonoBehaviour
{
    private GameObject door;
    public bool status;
    public void Start()
    {
        door=DoorController.Instance.Door(1);
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Character")&& status==false)
        {
            status = true;
            door.GetComponent<Animator>().SetBool("DoorStatus", false);
            SoundManager.Instance.Audio(27,PlayerPrefs.GetFloat("audioVolume"));

        }
    }
}


