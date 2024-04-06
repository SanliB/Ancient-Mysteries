using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    public FinalPanel FinalPanel;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Character")
        {
            FinalPanel.GetComponent<FinalPanel>().FinalScreen();
        }
    }
}
