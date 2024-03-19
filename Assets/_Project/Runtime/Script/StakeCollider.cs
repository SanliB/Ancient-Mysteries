using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeCollider : MonoBehaviour
{
    public BoxCollider _stakeCollider;
    // Start is called before the first frame update
    void Start()
    {
        _stakeCollider = GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("DieScene");
    }
}
