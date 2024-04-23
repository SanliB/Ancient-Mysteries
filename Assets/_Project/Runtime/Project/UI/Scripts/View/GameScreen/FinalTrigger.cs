using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    public CharacterController2 CharacterControl;
    public FinalPanel FinalPanel;
    public AudioSource Walksound;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Character")
        {
            CharacterControl.enabled = false;
            Walksound.Stop();
            FinalPanel.GetComponent<EndGameText>().TextStart();
            
        }
    }
}
