using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StakeCollider : MonoBehaviour
{
    public BoxCollider _stakeCollider;

    public DeathPanel panel;
    
    void Start()
    {
        _stakeCollider = GetComponent<BoxCollider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            panel.GetComponent<DeathPanel>().returnGame();
        }
    }
}
